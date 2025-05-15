using RazorLight;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RecoCms6.Services.TemplateEngine
{
    public static class TemplateBuilder
    {
        public static async Task<string> Build(string templateName, Object model)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            
            var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(path)
                .UseMemoryCachingProvider()
                .Build();

            return await engine.CompileRenderAsync($"Templates/{templateName}.cshtml", model);
        }

        public static string BuildClaimReport(RecoCms6.Models.RecoDb.ClaimReportDetail claimReport)
        {
            string bodyHtml = "<br/><p align='center'><b>CLAIM REPORT</b><br/><br/>";
            if (claimReport.InitialReport)
                bodyHtml += "Initial Report";
            else
                bodyHtml += "UPDATE";

            bodyHtml += "<br/>Claim No: " + claimReport.ClaimNo + "</p>";
            bodyHtml += "<p align='center'>Current Status:" + claimReport.Status + "</p>";
            bodyHtml += "<p align='center'>Insured: " + claimReport.Insureds + "</p>";
            bodyHtml += "<p align='center'>DATE SUBMITTED: " + DateTime.Now.ToLongDateString() + "</p>";
            bodyHtml += "<br/><br/>BROKER: " + claimReport.Broker + "<br/><br/>";
            bodyHtml += "CLAIMANT: " + claimReport.Claimants + "<br/><br/>";
            bodyHtml += "REPORT BY: " + claimReport.SubmittedByName + "<br/><br/>";
            if (claimReport.ClaimReportFlagID != null)
                bodyHtml += "FLAGGED AS: " + claimReport.ClaimReportFlag + "<br/><br/>";
            bodyHtml += "EXECUTIVE SUMMARY:";
            bodyHtml += "<blockquote>" + claimReport.ExecutiveSummary + "</blockquote><br/>";
            bodyHtml += "FACTS: <blockquote>" + claimReport.Facts + "</blockquote><br/>";
            bodyHtml += "COVERAGE: <blockquote>" + claimReport.Coverage + "</blockquote><br/>";
            bodyHtml += "LIABILITY: <blockquote>" + claimReport.Liability + "</blockquote><br/>";
            bodyHtml += "DAMAGES: <blockquote>" + claimReport.Damages + "</blockquote><br/>";
            bodyHtml += "RESERVES:<br/> <blockquote>";
            bodyHtml += "ESTIMATED EXPENSES:</br>" + claimReport.EstimatedExpenses + "</br>";
            bodyHtml += "&nbsp;&nbsp;&nbsp;&nbsp;<br/>ESTIMATED INDEMNITY:";
            bodyHtml += "&nbsp;&nbsp;&nbsp;&nbsp;<br/>Damages Claimed: " + claimReport.DamagesClaimed + "<br/>";
            bodyHtml += "&nbsp;&nbsp;&nbsp;&nbsp;<br/>Settlement Value: " + claimReport.EstimatedIndemnity + "<br/>";
            bodyHtml += "&nbsp;&nbsp;&nbsp;&nbsp;<br/>POSSIBLE SUBROGATION/RECOVERY: " + claimReport.PossibleSubrogation + "<br/>";
            bodyHtml += "UPDATE: <blockquote>" + claimReport.ActionPlan + "</blockquote><br/>";
            bodyHtml += "RECOMMENDATIONS: <blockquote>" + claimReport.Recommendations + "</blockquote><br/>";

            return bodyHtml;
        }

        public static string BuildAttachMailToClaim(RecoCms6.Models.RecoMail recoMail)
        {
            string bodyHtml = "<p style='text-align: center;'><strong><span style='font-size: 14px;'>EMAIL Attachment</span></strong></p>";
            bodyHtml += "<p style='text-align: center;'><span style='font-size: 12px;'>Subject: " + recoMail.Subject + "&nbsp;</span></p>";
            bodyHtml += "<p style = 'text-align: center;'><span style = 'font-size: 12px;'>From: " + recoMail.From + "</span></p>" ;
            bodyHtml += "<p style = 'text-align: center;'><span style = 'font-size: 12px;'>To: " + String.Join(";",recoMail.To) + "</span></p>";
            if (recoMail.CC != null && recoMail.CC.Any())
                bodyHtml += "<p style = 'text-align: center;'><span style = 'font-size: 12px;'>CC: " + String.Join(";", recoMail.CC) + "</span></p>";

            bodyHtml += "<p style = 'text-align: center;'><span style = 'font-size: 12px;'>" + DateTime.Now.ToString() + "</span></p><hr/>";
            bodyHtml += "<p style = 'text-align: left;' ><span style = 'font-size: 12px;'><br/></span></p>";
            bodyHtml += "<p style = 'text-align: left;' ><span style = 'font-size: 12px;'><br/></span></p>";

            if ((recoMail.ClaimFiles != null && recoMail.ClaimFiles.Any()) || (recoMail.Files != null && recoMail.Files.Any()) || (recoMail.Notes != null && recoMail.Notes.Any()))
            {
                bodyHtml += "<hr/><p style = 'text-align: center;'><span style = 'font-size: 12px;'>Attachments: </span></p><p>";
                if (recoMail.ClaimFiles != null)
                    foreach (var file in recoMail.ClaimFiles)
                        bodyHtml += file.Filename.ToString() + "<br/>";

                if (recoMail.Files != null)
                    foreach (var file in recoMail.Files)
                        bodyHtml += file.Name.ToString() + "<br/>";

                if (recoMail.Notes != null && recoMail.Notes.Any())
                    bodyHtml += "Notes.pdf <br/>";

                bodyHtml += "<p style = 'text-align: left;' ><span style = 'font-size: 12px;'><br/></span></p>";
                bodyHtml += "<p style = 'text-align: left;' ><span style = 'font-size: 12px;'><br/></span></p>";
            }
            bodyHtml += recoMail.Message;

            return bodyHtml;
        }

        public static string BuildNotesAttachment(RecoCms6.Models.RecoMail recoMail)
        {
            string bodyHtml = "<p style='text-align: center;'><strong><span style='font-size: 12pt;'>CLAIM NOTES</span></strong></p>";
            bodyHtml= "<p style='text-align: center;'><span style='font-size: 12px;'>Claim No: " + recoMail.Claimlist.ClaimNo + "</span></p>";
            bodyHtml = "<p style='text-align: center;'><span style='font-size: 12px;'>Current Status: " + recoMail.Claimlist.Status + "&nbsp;</span></p>";
            bodyHtml = "<p style = 'text-align: center;'><span style='font-size: 12px;'>Insured: " + recoMail.Claimlist.Insureds + "</span></p>";
            bodyHtml += "<p style = 'text-align: left;' ><span style = 'font-size: 12px;'><br/></span></p>";
            bodyHtml += "<p style = 'text-align: left;' ><span style = 'font-size: 12px;'><br/></span></p>";

            foreach (var note in recoMail.Notes)
            {
                bodyHtml += "<br/><br/><br/>";
                bodyHtml += "<p style='text-align: left;'><span style='font-size: 12px;'>﻿﻿<strong>Date:</strong>" + note.EntryDate.ToLongDateString() + "</span></p>";
                bodyHtml += "<p style = 'text-align: left;'><span style = 'font-size: 12px;'><strong>Subject: </strong>" + note.Subject+ "<strong>​</strong></span></p>";
                bodyHtml += "<p style = 'text-align: left;'><span style = 'font-size: 12px;'><strong>Author: </strong>" + note.Name + "</span></p>";
                bodyHtml += "<p style = 'text-align: left;'><span style = 'font-size: 12px;' ><strong>Details:</strong ></span></p><br/><br/>";
                bodyHtml += note.Details;
            }
            return bodyHtml;
        }
    }
}
