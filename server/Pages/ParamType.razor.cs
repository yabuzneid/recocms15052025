using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;
namespace RecoCms6.Pages
{
    public partial class ParamTypeComponent
    {
        public void EditRow(Parameter param)
        {
            grid1.EditRow(param);
        }

        public void EditParamType(RecoCms6.Models.RecoDb.ParamType paramType)
        {
            grid0.EditRow(paramType);
        }

        public async void UpdateParamType(RecoCms6.Models.RecoDb.ParamType paramType)
        {
            await grid0.UpdateRow(paramType);
            await RecoDb.UpdateParamType(paramType.ParamTypeID, paramType);
        }
        public async void UpdateRow(Parameter param)
        {
            await grid1.UpdateRow(param);
            await RecoDb.UpdateParameter(param.ParameterID, param);
        }

        public void CancelEdit(Parameter param)
        {
            grid1.CancelEditRow(param);
        }
        public void CancelEditParamType(RecoCms6.Models.RecoDb.ParamType paramType)
        {
            grid0.CancelEditRow(paramType);
        }

    }
}
