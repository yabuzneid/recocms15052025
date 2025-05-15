using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecoCms6.Data;
using System.IO;
using Syncfusion.XlsIO;
using Radzen;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using RecoCms6.Models;

namespace RecoCms6.Controllers;

public class DownloadController(RecoDbContext context, RecoDbService RecoDb, SecurityService Security)
    : ExportController
{
    private const string NoDataFound = "No Data Found";
    private readonly SecurityService Security = Security;

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/export/RecoDb/generatedinvoice/pdf(FileID={FileID})")]
    public async Task<FileStreamResult> ExportGeneratedInvoiceAsync(int FileID)
    {

        //var recoDbGetInvoiceUploadFileByFileIdResult = await RecoDb.GetInvoiceUploadFileByFileId(FileID);
        var recoDbGetInvoiceUploadFileByFileIdResult = context.InvoiceUploadFiles.Find(FileID);

        var invoiceuploadfile = recoDbGetInvoiceUploadFileByFileIdResult;
        MemoryStream stream = new MemoryStream(recoDbGetInvoiceUploadFileByFileIdResult.GeneratedInvoice);
        var result = new FileStreamResult(stream, "application/pdf");
        result.FileDownloadName = recoDbGetInvoiceUploadFileByFileIdResult.GeneratedInvoiceFilename;

        return result;
    }

    [HttpGet("/download/file/FileID={FileID}")]
    public async Task<FileStreamResult> DownloadFile(string FileID)
    {
        var document = context.Files.Single(f => f.ID == new Guid(FileID)).StoredDocument;
        var stream = new MemoryStream(document);
        //if (stream != null)
        //{
        return File(stream, "application/octet-stream");
        //}
        //else
        //{
        //    return NotFound();
        //}
    }

    [HttpGet("/downloadfullfile/FileID={FileID}")]
    public async Task<FileStreamResult> DownloadFileWithName(int FileID)
    {
        var file = context.Files.Single(f => f.FileID == FileID);
        var document = file.StoredDocument;

        MemoryStream stream = new MemoryStream(file.StoredDocument);
        var result = new FileStreamResult(stream, file.ContentType);
        result.FileDownloadName = file.Filename;

        return result;
    }

    [HttpGet("/downloadfullfile/actuarybordereau/UserID={UserID}")]
    public async System.Threading.Tasks.Task<FileStreamResult> ExportActuaryBordereausToExcel(int UserID)
    {
            
        var recoDbGetGetReportDatesResult = await RecoDb.GetGetReportDates(UserID);
        var reportDate = recoDbGetGetReportDatesResult.FirstOrDefault().ReportDate;
        DateTime dtReportDate = DateTime.Today;

        if (reportDate != null)
            dtReportDate = (DateTime)reportDate;

        string filename = "actuarybordereau_" + dtReportDate.ToString("MMMM_yyyy_") + DateTime.Today.ToString("yyyyMMdd") +".xlsx";

            
        string strReportDate = dtReportDate.ToString();

        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            //DateTime dt = new DateTime(ReportDate);
            var reportList = await RecoDb.GetActuaryBordereaus(strReportDate);

            //var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID" });

            var contractProgramList = reportList.Select(rl => new { Program = rl.Program }).Distinct().OrderByDescending(rl => rl.Program);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims and Expense Bordereau (" + dtReportDate.ToString("MMMM yyyy") + ") - ";
            string sheetTitle = String.Empty;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var currentProgram in contractProgramList)
            {
                var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamDesc == @0 && i.ParamTypeDesc==@1", FilterParameters = new object[] { currentProgram.Program, "ProgramID" }, OrderBy = $"ParameterID" });
                var program = programs.FirstOrDefault();
                abbrev = program.ParamAbbrev;
                if (abbrev == "EO") abbrev = "E_O";
                sheetTitle = baseTitle + program.ParamDesc;

                IWorksheet worksheet = workbook.Worksheets.Create(abbrev);

                var worksheetList = reportList.Where(rl => rl.Program == currentProgram.Program).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 1, 1);
                string lastRow = worksheet.UsedRange.LastRow.ToString();
            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;
        }
    }

    [HttpGet("/downloadfullfile/reservechangehistory/UserID={UserID}")]
    public async Task<FileStreamResult> ExportReserveChangeHistoryToExcel(int UserID, string startDate, string endDate, int? programId)
    {
        var recoDbGetGetReportDatesResult = await RecoDb.GetGetReportDates(UserID);
        var reportDate = recoDbGetGetReportDatesResult.FirstOrDefault()?.ReportDate;
        var dtReportDate = DateTime.Today;

        if (reportDate != null)
            dtReportDate = (DateTime)reportDate;

        var filename = "reservechangehistory_" + dtReportDate.ToString("MMMM_yyyy_") + DateTime.Today.ToString("yyyyMMdd") +".xlsx";

        using ExcelEngine excelEngine = new ExcelEngine();

        var application = excelEngine.Excel;
        application.DefaultVersion = ExcelVersion.Excel2013;
        
        // A new workbook is created equivalent to creating a new workbook in Excel
        // Create a workbook with 1 worksheet
        var workbook = application.Workbooks.Create(1);

        var reserveChangeHistories = (await RecoDb.GetReserveChangeHistories(startDate, endDate, programId)).ToList();

        var worksheet = workbook.Worksheets[0];
        worksheet.Range["A1"].Text = "Claim No";
        worksheet.Range["B1"].Text = "Amount Claimed";
        worksheet.Range["C1"].Text = "Claim Date";
        worksheet.Range["D1"].Text = "Transaction Date";
        worksheet.Range["E1"].Text = "Indemnity Increased";
        worksheet.Range["F1"].Text = "Indemnity Decreased";
        worksheet.Range["G1"].Text = "Adjusting Increased";
        worksheet.Range["H1"].Text = "Adjusting Decreased";
        worksheet.Range["I1"].Text = "Legal Increased";
        worksheet.Range["J1"].Text = "Legal Decreased";

        worksheet.Range["A1:J1"].CellStyle.Font.Bold = true;
        
        for (var i = 0; i < reserveChangeHistories.Count; i++)
        {
            var row = i + 2;
            worksheet.Range[$"A{row}"].Text = reserveChangeHistories[i].ClaimNo;
            worksheet.Range[$"B{row}"].Number = Convert.ToDouble(reserveChangeHistories[i].AmountClaimed);
            worksheet.Range[$"C{row}"].DateTime = Convert.ToDateTime(reserveChangeHistories[i].ClaimDate);
            worksheet.Range[$"D{row}"].DateTime = Convert.ToDateTime(reserveChangeHistories[i].TransactionDate);
            worksheet.Range[$"E{row}"].Number = Convert.ToDouble(reserveChangeHistories[i].IndemnityIncreased);
            worksheet.Range[$"F{row}"].Number = Convert.ToDouble(reserveChangeHistories[i].IndemnityDecreased);
            worksheet.Range[$"G{row}"].Number = Convert.ToDouble(reserveChangeHistories[i].AdjustingIncreased);
            worksheet.Range[$"H{row}"].Number = Convert.ToDouble(reserveChangeHistories[i].AdjustingDecreased);
            worksheet.Range[$"I{row}"].Number = Convert.ToDouble(reserveChangeHistories[i].LegalIncreased);
            worksheet.Range[$"J{row}"].Number = Convert.ToDouble(reserveChangeHistories[i].LegalDecreased);
        }

        if (reserveChangeHistories.Count > 0)
        {
            worksheet.Range["B2:B" + (reserveChangeHistories.Count + 1)].NumberFormat = "$#,##0.00";
            worksheet.Range["C2:C" + (reserveChangeHistories.Count + 1)].NumberFormat = "mm/dd/yyyy";
            worksheet.Range["D2:D" + (reserveChangeHistories.Count + 1)].NumberFormat = "mm/dd/yyyy hh:mm:ss AM/PM";
            worksheet.Range["E2:J" + (reserveChangeHistories.Count + 1)].NumberFormat = "$#,##0.00";
        }

        var stream = new MemoryStream();
        workbook.SaveAs(stream);
        stream.Position = 0;
        var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        result.FileDownloadName = filename;
        
        return result;
    }

    [HttpGet("/downloadfullfile/serviceproviderbordereau/UserID={UserID}&FirmID={FirmID}")]
    public async System.Threading.Tasks.Task<FileStreamResult> ExportServiceProviderBordereausToExcel(int UserID, int FirmID)
    {

        var recoDbGetGetReportDatesResult = await RecoDb.GetGetReportDates(UserID);
        var reportDate = recoDbGetGetReportDatesResult.FirstOrDefault().ReportDate;
            
        DateTime dtReportDate = DateTime.Today;

        var firms = await RecoDb.GetFirmDetails(new Query() { Filter = $@"i=>i.FirmType==@0", FilterParameters = new Object[] { "Defense Counsel" }, OrderBy = $"Name" });

        string filename = "Service Provider_bordereau_" + DateTime.Now.ToString("MMMM yyyy") + ".xlsx";

        if (FirmID > 0)
        {
            firms = firms.Where(f => f.FirmID == FirmID);
            filename = firms.First().Name + "_bordereau_" + DateTime.Now.ToString("MMMM yyyy") + ".xlsx";
        }           

        if (reportDate != null)
            dtReportDate = (DateTime)reportDate;

        string strReportDate = dtReportDate.ToString();

        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            //DateTime dt = new DateTime(ReportDate);
            var reportList = await RecoDb.GetServiceProviderBordereaus(strReportDate);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims {firm} Bordereau (" + dtReportDate.ToString("MMMM yyyy") + ")";
            string sheetTitle = String.Empty;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var firm in firms)
            {
                sheetTitle = baseTitle.Replace("{firm}", firm.Name);

                abbrev = GetFirmAbbrev(firm.Name);
                var worksheetList = reportList.Where(rl => rl.DefenseFirm == firm.Name).ToList();

                if (worksheetList != null && worksheetList.Count() > 0)
                {

                    IWorksheet worksheet = workbook.Worksheets.Create(abbrev);
                    worksheet.Range["A1"].Text = sheetTitle;
                    worksheet.Range["A1"].CellStyle = style2;
                    worksheet.ImportDataTable(ToDataTable(worksheetList), true,4, 1);
                        
                    worksheet.DeleteColumn(1, 2);

                    worksheet.Range["A1"].Text = sheetTitle;
                    worksheet.Range["A1"].CellStyle = style2;

                    //Setup totals
                    string lastRow = worksheet.UsedRange.LastRow.ToString();
                    string totalRow = (worksheet.UsedRange.LastRow + 1).ToString();
                    worksheet.Range["V" + totalRow].Formula = "=SUM(V5:V" + lastRow + ")";
                    worksheet.Range["W" + totalRow].Formula = "=SUM(W5:W" + lastRow + ")";
                    worksheet.Range["X" + totalRow].Formula = "=SUM(X5:X" + lastRow + ")";
                    worksheet.Range["Y" + totalRow].Formula = "=SUM(Y5:Y" + lastRow + ")";
                    worksheet.Range["Z" + totalRow].Formula = "=SUM(Z5:Z" + lastRow + ")";
                    worksheet.Range["AA" + totalRow].Formula = "=SUM(AA5:AA" + lastRow + ")";
                    worksheet.Range["AB" + totalRow].Formula = "=SUM(AB5:AB" + lastRow + ")";
                    worksheet.Range["AC" + totalRow].Formula = "=SUM(AC5:AC" + lastRow + ")";
                    worksheet.Range["AD" + totalRow].Formula = "=SUM(AD5:AD" + lastRow + ")";
                    worksheet.Range["AE" + totalRow].Formula = "=SUM(AE5:AE" + lastRow + ")";
                    worksheet.Range["AF" + totalRow].Formula = "=SUM(AF5:AF" + lastRow + ")";
                    worksheet.Range["AG" + totalRow].Formula = "=SUM(AG5:AG" + lastRow + ")";
                    worksheet.Range["AH" + totalRow].Formula = "=SUM(AH5:AH" + lastRow + ")";
                    worksheet.Range["AI" + totalRow].Formula = "=SUM(AI5:AI" + lastRow + ")";
                    worksheet.Range["AJ" + totalRow].Formula = "=SUM(AJ5:AJ" + lastRow + ")";
                    worksheet.Range["AK" + totalRow].Formula = "=SUM(AK5:AK" + lastRow + ")";
                    worksheet.Range["AL" + totalRow].Formula = "=SUM(AL5:AL" + lastRow + ")";
                    worksheet.Range["V5:AL" + totalRow].NumberFormat = "$#,##0.00";
                    worksheet.Range["P5:S" + totalRow].NumberFormat = "mm/dd/yyyy";
                }

                    

            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;
        }
    }

    private string GetFirmAbbrev(string FirmName)
    {
        string result = String.Empty;
        string[] strSplit = FirmName.Split();
        foreach (string res in strSplit)
            result += res.Substring(0, 1);

        return result;
    }

    [HttpGet("/download/movementbordereau/UserID={UserID}")]
    public async System.Threading.Tasks.Task<FileStreamResult> ExportMovementBordereausToExcel(int UserID)
    {

        var recoDbGetGetReportDatesResult = await RecoDb.GetGetReportDates(UserID);
        var reportDate = (DateTime)recoDbGetGetReportDatesResult.FirstOrDefault().ReportDate;
        var startDate = (DateTime)recoDbGetGetReportDatesResult.FirstOrDefault().StartDate;

        DateTime dtReportDate = DateTime.Today;
        string filename = "movementbordereau_" + startDate.ToString("yyyy-MM-dd") + "-" + reportDate.ToString("yyyy-MM-dd")  + ".xlsx";

        if (reportDate != null)
            dtReportDate = (DateTime)reportDate;



        string strReportDate = dtReportDate.ToString();
        string strStartDate = startDate.ToString();

        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            //DateTime dt = new DateTime(ReportDate);
            var reportList = await RecoDb.GetMovementBordereaus(strReportDate,strStartDate);

            //var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID" });

            var contractProgramList = reportList.Select(rl => new { Program = rl.Program }).Distinct().OrderByDescending(rl => rl.Program);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims Movement Bordereau (" + startDate.ToString("yyyy-MM-dd") + "-" + reportDate.ToString("yyyy-MM-dd") + ") -";
            string sheetTitle = String.Empty;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var currentProgram in contractProgramList)
            {
                var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamDesc == @0 && i.ParamTypeDesc==@1", FilterParameters = new object[] { currentProgram.Program, "ProgramID" }, OrderBy = $"ParameterID" });
                var program = programs.FirstOrDefault();
                abbrev = program.ParamAbbrev;
                if (abbrev == "EO") abbrev = "E_O";
                sheetTitle = baseTitle + program.ParamDesc;

                IWorksheet worksheet = workbook.Worksheets.Create(abbrev);

                var worksheetList = reportList.Where(rl => rl.Program == currentProgram.Program).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 1, 1);
                    
                worksheet.DeleteColumn(1,1);

                string lastRow = worksheet.UsedRange.LastRow.ToString();
            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;
        }
    }

    [HttpGet("/downloadfullfile/lloydsbordereau/UserID={UserID}")]
    public async Task<FileStreamResult> DownloadLloydsBordereauToExcel(int UserID)
    {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            string filename = "lloydsbordereau_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;
                
            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            //DateTime dt = new DateTime(ReportDate);
            var recoDbGetGetReportDatesResult = await RecoDb.GetGetReportDates(UserID);
            var reportDate = recoDbGetGetReportDatesResult.FirstOrDefault().ReportDate;
                
            DateTime dtReportDate = DateTime.Today;

            if (reportDate != null)
                dtReportDate = (DateTime)reportDate;

            string strReportDate = dtReportDate.ToString();

            var reportList = await RecoDb.GetRecoLloydsBordereaus(strReportDate);

            //var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID" });

            var contractProgramYears = reportList.Select(rl => new {ContractYear=rl.ContractYear,ProgramID=rl.ClaimTypeID}).Distinct().OrderBy(rl=>rl.ProgramID).ThenBy(rl=>rl.ContractYear);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims and Expense Bordereau (" + dtReportDate.ToString("MMMM yyyy") + ") - ";
            string sheetTitle = String.Empty;
                
            int currentProgramID = 0;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var contractProgramYear in contractProgramYears)
            {
                if (contractProgramYear.ProgramID != currentProgramID)
                {
                    var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { contractProgramYear.ProgramID }, OrderBy = $"ParameterID" });
                    var program = programs.FirstOrDefault();
                    abbrev = program.ParamAbbrev;
                    if (abbrev == "EO") abbrev = "E_O";
                    sheetTitle = baseTitle + program.ParamDesc;
                }

                IWorksheet worksheet = workbook.Worksheets.Create(contractProgramYear.ContractYear.Substring(2)+"-"+abbrev);

                var worksheetList = reportList.Where(rl => rl.ClaimTypeID == contractProgramYear.ProgramID && rl.ContractYear== contractProgramYear.ContractYear).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 4, 1);
                string lastRow = worksheet.UsedRange.LastRow.ToString();
                worksheet.DeleteColumn(1, 2);
                    
                worksheet.Range["A1"].Text = sheetTitle;
                worksheet.Range["A1"].CellStyle = style2;
                worksheet.Range["A3"].Text = contractProgramYear.ContractYear + " Contract Year";
                worksheet.Range["A3"].CellStyle = style1;

                //Setup totals
                string totalRow = (worksheet.UsedRange.LastRow + 1).ToString();
                worksheet.Range["R" + totalRow].Formula = "=SUM(R5:R" + lastRow + ")";
                worksheet.Range["S" + totalRow].Formula = "=SUM(S5:S" + lastRow + ")";
                worksheet.Range["T" + totalRow].Formula = "=SUM(T5:T" + lastRow + ")";
                worksheet.Range["U" + totalRow].Formula = "=SUM(U5:U" + lastRow + ")";
                worksheet.Range["V" + totalRow].Formula = "=SUM(V5:V" + lastRow + ")";
                worksheet.Range["W" + totalRow].Formula = "=SUM(W5:W" + lastRow + ")";
                worksheet.Range["X" + totalRow].Formula = "=SUM(X5:X" + lastRow + ")";
                worksheet.Range["Y" + totalRow].Formula = "=SUM(Y5:Y" + lastRow + ")";
                worksheet.Range["Z" + totalRow].Formula = "=SUM(Z5:Z" + lastRow + ")";
                worksheet.Range["AA" + totalRow].Formula = "=SUM(AA5:AA" + lastRow + ")";
                worksheet.Range["AB" + totalRow].Formula = "=SUM(AB5:AB" + lastRow + ")";
                worksheet.Range["AC" + totalRow].Formula = "=SUM(AC5:AC" + lastRow + ")";
                worksheet.Range["AD" + totalRow].Formula = "=SUM(AD5:AD" + lastRow + ")";
                worksheet.Range["AE" + totalRow].Formula = "=SUM(AE5:AE" + lastRow + ")";
                worksheet.Range["AF" + totalRow].Formula = "=SUM(AF5:AF" + lastRow + ")";
                worksheet.Range["AG" + totalRow].Formula = "=SUM(AG5:AG" + lastRow + ")";
                worksheet.Range["AH" + totalRow].Formula = "=SUM(AH5:AH" + lastRow + ")";

                worksheet.Range["R" + totalRow + ":AH" + totalRow].CellStyle = style1;

                worksheet.Range["N5:Q" + totalRow].NumberFormat = "mm/dd/yyyy";
                worksheet.Range["R5:AH" + totalRow].NumberFormat = "$#,##0.00";
                worksheet.Range["AU5:AU" + totalRow].NumberFormat = "mm/dd/yyyy";
                worksheet.Range["AL5:AL" + totalRow].NumberFormat = "mm/dd/yyyy";
                worksheet.Range["AW5:AW" + totalRow].NumberFormat = "mm/dd/yyyy";
            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;

        }
    }

    [HttpGet("/download/fullbordereau/UserID={UserID}")]
    public async Task<FileStreamResult> DownloadFullBordereauToExcel(int UserID)
    {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            string filename = "fullbordereau_" + DateTime.Now.ToString("MMMM yyyy") + ".xlsx";
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            //DateTime dt = new DateTime(ReportDate);
            var recoDbGetGetReportDatesResult = await RecoDb.GetGetReportDates(UserID);
            var reportDate = recoDbGetGetReportDatesResult.FirstOrDefault().ReportDate;

            DateTime dtReportDate = DateTime.Today;

            if (reportDate != null)
                dtReportDate = (DateTime)reportDate;

            string strReportDate = dtReportDate.ToString();

            var reportList = await RecoDb.GetFullBordereaus(strReportDate);

            //var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID" });

            var contractProgramYears = reportList.Select(rl => new { ContractYear = rl.ContractYear, ProgramID = rl.ProgramID }).Distinct().OrderBy(rl => rl.ProgramID).ThenBy(rl => rl.ContractYear);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims Bordereau (" + dtReportDate.ToString("MMMM yyyy") + ") - ";
            string sheetTitle = String.Empty;

            int currentProgramID = 0;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var contractProgramYear in contractProgramYears)
            {
                if (contractProgramYear.ProgramID != currentProgramID)
                {
                    var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { contractProgramYear.ProgramID }, OrderBy = $"ParameterID" });
                    var program = programs.FirstOrDefault();
                    abbrev = program.ParamAbbrev;
                    if (abbrev == "EO") abbrev = "E_O";
                    sheetTitle = baseTitle + program.ParamDesc;
                }

                IWorksheet worksheet = workbook.Worksheets.Create(contractProgramYear.ContractYear.Substring(2,2) + "-" + abbrev);

                var worksheetList = reportList.Where(rl => rl.ProgramID == contractProgramYear.ProgramID && rl.ContractYear == contractProgramYear.ContractYear).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 4, 1);
                string lastRow = worksheet.UsedRange.LastRow.ToString();
                worksheet.DeleteColumn(1, 1);

                worksheet.Range["A1"].Text = sheetTitle;
                worksheet.Range["A1"].CellStyle = style2;
                worksheet.Range["A3"].Text = contractProgramYear.ContractYear + " Contract Year";
                worksheet.Range["A3"].CellStyle = style1;

                //Setup totals
                string totalRow = (worksheet.UsedRange.LastRow + 1).ToString();
                worksheet.Range["AN" + totalRow].Formula = "=SUM(AN5:AN" + lastRow + ")";
                worksheet.Range["AO" + totalRow].Formula = "=SUM(AO5:AO" + lastRow + ")";
                worksheet.Range["AP" + totalRow].Formula = "=SUM(AP5:AP" + lastRow + ")";
                worksheet.Range["AQ" + totalRow].Formula = "=SUM(AQ5:AQ" + lastRow + ")";
                worksheet.Range["AR" + totalRow].Formula = "=SUM(AR5:AR" + lastRow + ")";
                worksheet.Range["AS" + totalRow].Formula = "=SUM(AS5:AS" + lastRow + ")";
                worksheet.Range["AT" + totalRow].Formula = "=SUM(AT5:AT" + lastRow + ")";
                worksheet.Range["AU" + totalRow].Formula = "=SUM(AU5:AU" + lastRow + ")";
                worksheet.Range["AV" + totalRow].Formula = "=SUM(AV5:AV" + lastRow + ")";
                worksheet.Range["AW" + totalRow].Formula = "=SUM(AW5:AW" + lastRow + ")";
                worksheet.Range["AX" + totalRow].Formula = "=SUM(AX5:AX" + lastRow + ")";
                worksheet.Range["AY" + totalRow].Formula = "=SUM(AY5:AY" + lastRow + ")";
                worksheet.Range["AZ" + totalRow].Formula = "=SUM(AZ5:AZ" + lastRow + ")";
                worksheet.Range["BA" + totalRow].Formula = "=SUM(BA5:BA" + lastRow + ")";

                worksheet.Range["AN" + totalRow + ":BA" + totalRow].CellStyle = style1;

                worksheet.Range["U5:AB" + totalRow].NumberFormat = "mm/dd/yyyy";
                worksheet.Range["AN5:BA" + totalRow].NumberFormat = "$#,##0.00";
            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;

        }
    }

    [HttpGet("/download/largeloss/UserID={UserID}")]
    public async Task<FileStreamResult> DownloadLargeLossToExcel(int UserID)
    {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            string filename = "largeloss_" + DateTime.Now.ToString("MMMM yyyy") + ".xlsx";
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            //DateTime dt = new DateTime(ReportDate);
            var recoDbGetGetReportDatesResult = await RecoDb.GetGetReportDates(UserID);
            var reportDate = recoDbGetGetReportDatesResult.FirstOrDefault().ReportDate;

            DateTime dtReportDate = DateTime.Today;

            if (reportDate != null)
                dtReportDate = (DateTime)reportDate;

            string strReportDate = dtReportDate.ToString();

            var reportList = await RecoDb.GetLargeLossBordereaus(strReportDate);

            //var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID" });

            var contractProgramYears = reportList.Select(rl => new { ContractYear = rl.ContractYear, ProgramID = rl.ProgramID }).Distinct().OrderBy(rl => rl.ProgramID).ThenBy(rl => rl.ContractYear);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims Bordereau (" + dtReportDate.ToString("MMMM yyyy") + ") - ";
            string sheetTitle = String.Empty;

            int currentProgramID = 0;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var contractProgramYear in contractProgramYears)
            {
                if (contractProgramYear.ProgramID != currentProgramID)
                {
                    var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { contractProgramYear.ProgramID }, OrderBy = $"ParameterID" });
                    var program = programs.FirstOrDefault();
                    abbrev = program.ParamAbbrev;
                    if (abbrev == "EO") abbrev = "E_O";
                    sheetTitle = baseTitle + program.ParamDesc;
                }

                IWorksheet worksheet = workbook.Worksheets.Create(contractProgramYear.ContractYear.Substring(2, 2) + "-" + abbrev);

                var worksheetList = reportList.Where(rl => rl.ProgramID == contractProgramYear.ProgramID && rl.ContractYear == contractProgramYear.ContractYear).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 4, 1);
                string lastRow = worksheet.UsedRange.LastRow.ToString();
                worksheet.DeleteColumn(1, 1);

                worksheet.Range["A1"].Text = sheetTitle;
                worksheet.Range["A1"].CellStyle = style2;
                worksheet.Range["A3"].Text = contractProgramYear.ContractYear + " Contract Year";
                worksheet.Range["A3"].CellStyle = style1;

                //Setup totals
                string totalRow = (worksheet.UsedRange.LastRow + 1).ToString();
                worksheet.Range["AN" + totalRow].Formula = "=SUM(AN5:AN" + lastRow + ")";
                worksheet.Range["AO" + totalRow].Formula = "=SUM(AO5:AO" + lastRow + ")";
                worksheet.Range["AP" + totalRow].Formula = "=SUM(AP5:AP" + lastRow + ")";
                worksheet.Range["AQ" + totalRow].Formula = "=SUM(AQ5:AQ" + lastRow + ")";
                worksheet.Range["AR" + totalRow].Formula = "=SUM(AR5:AR" + lastRow + ")";
                worksheet.Range["AS" + totalRow].Formula = "=SUM(AS5:AS" + lastRow + ")";
                worksheet.Range["AT" + totalRow].Formula = "=SUM(AT5:AT" + lastRow + ")";
                worksheet.Range["AU" + totalRow].Formula = "=SUM(AU5:AU" + lastRow + ")";
                worksheet.Range["AV" + totalRow].Formula = "=SUM(AV5:AV" + lastRow + ")";
                worksheet.Range["AW" + totalRow].Formula = "=SUM(AW5:AW" + lastRow + ")";
                worksheet.Range["AX" + totalRow].Formula = "=SUM(AX5:AX" + lastRow + ")";
                worksheet.Range["AY" + totalRow].Formula = "=SUM(AY5:AY" + lastRow + ")";
                worksheet.Range["AZ" + totalRow].Formula = "=SUM(AZ5:AZ" + lastRow + ")";
                worksheet.Range["BA" + totalRow].Formula = "=SUM(BA5:BA" + lastRow + ")";

                worksheet.Range["AN" + totalRow + ":BA" + totalRow].CellStyle = style1;

                worksheet.Range["U5:AB" + totalRow].NumberFormat = "mm/dd/yyyy";
                worksheet.Range["AN5:BA" + totalRow].NumberFormat = "$#,##0.00";
            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;

        }
    }

    [HttpGet("/download/emptyreserves")]
    public async Task<FileStreamResult> DownloadEmptyReservesToExcel()
    {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            string filename = "emptyreserves_" + DateTime.Now.ToString("MMMM yyyy") + ".xlsx";
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            var reportList = await RecoDb.GetEmptyReserveBordereaus();

            //var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID" });

            var contractProgramYears = reportList.Select(rl => new { ContractYear = rl.ContractYear, ProgramID = rl.ProgramID }).Distinct().OrderBy(rl => rl.ProgramID).ThenBy(rl => rl.ContractYear);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims Bordereau (" + DateTime.Today.ToString("MMMM yyyy") + ") - ";
            string sheetTitle = String.Empty;

            int currentProgramID = 0;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var contractProgramYear in contractProgramYears)
            {
                if (contractProgramYear.ProgramID != currentProgramID)
                {
                    var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { contractProgramYear.ProgramID }, OrderBy = $"ParameterID" });
                    var program = programs.FirstOrDefault();
                    abbrev = program.ParamAbbrev;
                    if (abbrev == "EO") abbrev = "E_O";
                    sheetTitle = baseTitle + program.ParamDesc;
                }

                IWorksheet worksheet = workbook.Worksheets.Create(contractProgramYear.ContractYear.Substring(2, 2) + "-" + abbrev);

                var worksheetList = reportList.Where(rl => rl.ProgramID == contractProgramYear.ProgramID && rl.ContractYear == contractProgramYear.ContractYear).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 4, 1);
                string lastRow = worksheet.UsedRange.LastRow.ToString();
                worksheet.DeleteColumn(1, 1);

                worksheet.Range["A1"].Text = sheetTitle;
                worksheet.Range["A1"].CellStyle = style2;
                worksheet.Range["A3"].Text = contractProgramYear.ContractYear + " Contract Year";
                worksheet.Range["A3"].CellStyle = style1;
                    
            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;

        }
    }

    [HttpGet("/download/noactivediaries")]
    public async Task<FileStreamResult> DownloadNoActiveDiariesToExcel()
    {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            string filename = "noactivediaries_" + DateTime.Now.ToString("MMMM yyyy") + ".xlsx";
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            var reportList = await RecoDb.GetNoActiveDiaryBordereaus();

            //var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID" });

            var contractProgramYears = reportList.Select(rl => new { ContractYear = rl.ContractYear, ProgramID = rl.ClaimTypeID }).Distinct().OrderBy(rl => rl.ProgramID).ThenBy(rl => rl.ContractYear);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims Bordereau (" + DateTime.Today.ToString("MMMM yyyy") + ") - ";
            string sheetTitle = String.Empty;

            int currentProgramID = 0;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var contractProgramYear in contractProgramYears)
            {
                if (contractProgramYear.ProgramID != currentProgramID)
                {
                    var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { contractProgramYear.ProgramID }, OrderBy = $"ParameterID" });
                    var program = programs.FirstOrDefault();
                    abbrev = program.ParamAbbrev;
                    if (abbrev == "EO") abbrev = "E_O";
                    sheetTitle = baseTitle + program.ParamDesc;
                }

                IWorksheet worksheet = workbook.Worksheets.Create(contractProgramYear.ContractYear.Substring(2, 2) + "-" + abbrev);

                var worksheetList = reportList.Where(rl => rl.ClaimTypeID == contractProgramYear.ProgramID && rl.ContractYear == contractProgramYear.ContractYear).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 4, 1);
                string lastRow = worksheet.UsedRange.LastRow.ToString();
                worksheet.DeleteColumn(1, 1);

                worksheet.Range["A1"].Text = sheetTitle;
                worksheet.Range["A1"].CellStyle = style2;
                worksheet.Range["A3"].Text = contractProgramYear.ContractYear + " Contract Year";
                worksheet.Range["A3"].CellStyle = style1;

            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;

        }
    }

    [HttpGet("/download/activediaries/UserID={UserID}")]
    public async Task<FileStreamResult> DownloadActiveDiariesToExcel(int UserID)
    {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            string filename = "activediaries_" + DateTime.Now.ToString("MMMM yyyy") + ".xlsx";
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            var recoDbGetGetReportDatesResult = await RecoDb.GetGetReportDates(UserID);
            var reportDate = recoDbGetGetReportDatesResult.FirstOrDefault();
            var reportJson = JsonConvert.DeserializeObject<ReportJson>(reportDate.ReportJson);
                

            string spUserID = String.Empty;
            string spName = String.Empty;
            string baseTitle = "RECO Active User Diary Reports (" + DateTime.Today.ToString("MMMM yyyy") + ")";

            if (reportJson.UserID != Guid.Empty)
            {
                spUserID = reportJson.UserID.ToString();
                var serviceProviderResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { spUserID } });
                var specificServiceProvider = serviceProviderResult.FirstOrDefault();
                spName = specificServiceProvider.Name;
                baseTitle = baseTitle + " - For " + spName;
            }

            var reportList = await RecoDb.GetActiveUserDiaryReports(reportDate.StartDate.ToString(),reportDate.ReportDate.ToString(),spUserID);

            var claimTypeIds = reportList.Select(rl => new { ProgramID = rl.ClaimTypeID }).Distinct().OrderBy(rl => rl.ProgramID);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string sheetTitle = String.Empty;

            int currentProgramID = 0;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var claimTypeID in claimTypeIds)
            {
                if (claimTypeID.ProgramID != currentProgramID)
                {
                    var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { claimTypeID.ProgramID }, OrderBy = $"ParameterID" });
                    var program = programs.FirstOrDefault();
                    abbrev = program.ParamAbbrev;
                    if (abbrev == "EO") abbrev = "E_O";
                    sheetTitle = baseTitle + " " + program.ParamDesc;
                }

                IWorksheet worksheet = workbook.Worksheets.Create(abbrev);

                var worksheetList = reportList.Where(rl => rl.ClaimTypeID == claimTypeID.ProgramID).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 4, 1);
                string lastRow = worksheet.UsedRange.LastRow.ToString();

                worksheet.Range["A1"].Text = sheetTitle;
                worksheet.Range["A1"].CellStyle = style2;
                    
            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;

        }
    }

    [HttpGet("/download/currentdiary")]
    public async Task<FileStreamResult> DownloadCurrentDiaryToExcel()
    {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            string filename = "currentdiary_" + DateTime.Now.ToString("MMMM yyyy") + ".xlsx";
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            var reportList = await RecoDb.GetCurrentDiaryReports();

            //var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID" });

            var contractProgramYears = reportList.Select(rl => new { ContractYear = rl.ContractYear, ProgramID = rl.ClaimTypeID }).Distinct().OrderBy(rl => rl.ProgramID).ThenBy(rl => rl.ContractYear);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims Bordereau (" + DateTime.Today.ToString("MMMM yyyy") + ") - ";
            string sheetTitle = String.Empty;

            int currentProgramID = 0;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var contractProgramYear in contractProgramYears)
            {
                if (contractProgramYear.ProgramID != currentProgramID)
                {
                    var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { contractProgramYear.ProgramID }, OrderBy = $"ParameterID" });
                    var program = programs.FirstOrDefault();
                    abbrev = program.ParamAbbrev;
                    if (abbrev == "EO") abbrev = "E_O";
                    sheetTitle = baseTitle + program.ParamDesc;
                }

                IWorksheet worksheet = workbook.Worksheets.Create(contractProgramYear.ContractYear.Substring(2, 2) + "-" + abbrev);

                var worksheetList = reportList.Where(rl => rl.ClaimTypeID == contractProgramYear.ProgramID && rl.ContractYear == contractProgramYear.ContractYear).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 4, 1);
                string lastRow = worksheet.UsedRange.LastRow.ToString();
                worksheet.DeleteColumn(1, 1);

                worksheet.Range["A1"].Text = sheetTitle;
                worksheet.Range["A1"].CellStyle = style2;
                worksheet.Range["A3"].Text = contractProgramYear.ContractYear + " Contract Year";
                worksheet.Range["A3"].CellStyle = style1;

            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;

        }
    }

    [HttpGet("/download/lastdefense")]
    public async Task<FileStreamResult> DownloadLastDefenseToExcel()
    {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
            string filename = "lastdefense_" + DateTime.Now.ToString("MMMM yyyy") + ".xlsx";
            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A new workbook is created equivalent to creating a new workbook in Excel
            //Create a workbook with 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            var reportList = await RecoDb.GetLastDefenceClaimReports();

            //var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID" });

            var contractProgramYears = reportList.Select(rl => new { ContractYear = rl.ContractYear, ProgramID = rl.ProgramID }).Distinct().OrderBy(rl => rl.ProgramID).ThenBy(rl => rl.ContractYear);

            IStyle style1 = workbook.Styles.Add("NewStyle1");
            style1.Font.Bold = true;

            IStyle style2 = workbook.Styles.Add("NewStyle2");
            style2.Font.Bold = true;
            style2.Font.Underline = ExcelUnderline.Single;

            string baseTitle = "RECO Claims Bordereau (" + DateTime.Today.ToString("MMMM yyyy") + ") - ";
            string sheetTitle = String.Empty;

            int currentProgramID = 0;
            string contractyear = String.Empty;
            string abbrev = String.Empty;
            foreach (var contractProgramYear in contractProgramYears)
            {
                if (contractProgramYear.ProgramID != currentProgramID)
                {
                    var programs = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { contractProgramYear.ProgramID }, OrderBy = $"ParameterID" });
                    var program = programs.FirstOrDefault();
                    abbrev = program.ParamAbbrev;
                    if (abbrev == "EO") abbrev = "E_O";
                    sheetTitle = baseTitle + program.ParamDesc;
                }

                IWorksheet worksheet = workbook.Worksheets.Create(contractProgramYear.ContractYear.Substring(2, 2) + "-" + abbrev);

                var worksheetList = reportList.Where(rl => rl.ProgramID == contractProgramYear.ProgramID && rl.ContractYear == contractProgramYear.ContractYear).ToList();

                worksheet.ImportDataTable(ToDataTable(worksheetList), true, 4, 1);
                string lastRow = worksheet.UsedRange.LastRow.ToString();
                worksheet.DeleteColumn(1, 1);

                worksheet.Range["A1"].Text = sheetTitle;
                worksheet.Range["A1"].CellStyle = style2;
                worksheet.Range["A3"].Text = contractProgramYear.ContractYear + " Contract Year";
                worksheet.Range["A3"].CellStyle = style1;

            }

            if (workbook.Worksheets.Count() > 1)
                workbook.Worksheets.Remove(0);
            else
                workbook.Worksheets[0].Range["A1"].Text = NoDataFound;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = filename;

            return result;

        }
    }

    /// <summary>
    /// Convert a List{T} to a DataTable.
    /// </summary>
    public DataTable ToDataTable<T>(List<T> items)
    {
        var tb = new DataTable(typeof(T).Name);

        PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo prop in props)
        {
            Type t = GetCoreType(prop.PropertyType);
            tb.Columns.Add(prop.Name, t);
        }

        foreach (T item in items)
        {
            var values = new object[props.Length];

            for (int i = 0; i < props.Length; i++)
            {
                values[i] = props[i].GetValue(item, null);
            }

            tb.Rows.Add(values);
        }

        return tb;
    }

    /// <summary>
    /// Determine of specified type is nullable
    /// </summary>
    public static bool IsNullable(Type t)
    {
        return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
    }

    /// <summary>
    /// Return underlying type if type is Nullable otherwise return the type
    /// </summary>
    public static Type GetCoreType(Type t)
    {
        if (t != null && IsNullable(t))
        {
            if (!t.IsValueType)
            {
                return t;
            }
            else
            {
                return Nullable.GetUnderlyingType(t);
            }
        }
        else
        {
            return t;
        }
    }

}