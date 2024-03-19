using ApiSpeedUp.Data;
using Microsoft.EntityFrameworkCore;
using ApiSpeedUp.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ApiSpeedUp.SqlDataFetch
{
    public class ApiRepo : IApiRep
    {
        private readonly travelDbContext dbContext;

        public ApiRepo(travelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ApiExecutionTime>> GetAllList()
        { 
            return await dbContext.ApiExecutionTimes.ToListAsync();
        }

        public async Task<int> getcount(string org)
        {
            
            return await dbContext.ApiExecutionTimes.Where(r => r.OrganizationName == org).CountAsync();

        }

        public async Task<List<Distinct_Organization>> GetAllorg()
        {
            Distinct_Organization distinct_Organization = new Distinct_Organization();
            try
            {
                var distinctOrgNames = await dbContext.ApiExecutionTimes
                    .Select(r => new Distinct_Organization { orgname = r.OrganizationName })
                    .Distinct()
                    .ToListAsync();

                return distinctOrgNames;
            }
            catch (Exception ex)
            {
                throw;
                //return new Distinct_Organization();
            }

        }
    }
}

//public async Task<SapGetTerminalStoresResponse> GetShopByIds(SapGetTerminalStoresRequest request, string traceId, string agentId)
//{
//    SapGetTerminalStoresResponse response = new SapGetTerminalStoresResponse();
//    try
//    {
//        _serilogger.WriteLog(Severity.Debug, traceId, agentId, this.GetType().ToString(), CommonMessage.COMMERCE_TERMINALSTORE, LogFormat.JSON, LogType.Request, CommonMessage.COMMERCE_STARTTERMINALSTORE, request, LogDataModel.OTA, Enum.GetName(Functionality.GetTerminalStores.GetType(), Functionality.GetTerminalStores));
//        string ActionName = ActionNameURL.GetShopByID.ToString();
//        string url = appSettings.PortSetting.BaseUrl + appSettings.PortSetting.Actions.FirstOrDefault(x => x.Name == ActionName).Url;
//        if (!string.IsNullOrEmpty(request.storeId))
//        {
//            //url = url.Replace("{fields}", request.fields);
//            url = url.Replace("{shopId}", request.storeId);
//        }
//        // //PortHandler port = new PortHandler()
//        var portResponse = await port.Get(url, ActionName, appSettings.PortSetting);
//        response.Status = portResponse.Status;
//        response.Error = portResponse.Error;
//        if (!string.IsNullOrEmpty(portResponse.Content))
//        {
//            response = JsonConvert.DeserializeObject<SapGetTerminalStoresResponse>(portResponse.Content);
//            response.Status = portResponse.Status;
//        }
//        else
//        {
//            response.Status = portResponse.Status;
//        }
//        _serilogger.WriteLog(Severity.Debug, traceId, agentId, this.GetType().ToString(), CommonMessage.COMMERCE_TERMINALSTORE, LogFormat.JSON, LogType.Response, CommonMessage.COMMERCE_ENDTERMINALSTORE, response, LogDataModel.API, Enum.GetName(Functionality.GetTerminalStores.GetType(), Functionality.GetTerminalStores));
//    }
//    catch (Exception ex)
//    {
//        response.Status = false;
//        response.Code = ResponseCode.GTS003;
//        response.Message = ResponseMessage.GetMessage(ResponseCode.GTS003);
//        response = ExceptionHanddler.GetErrorResponse(ex, response);
//        response.Error = new Error()
//        {
//            StatusCode = System.Net.HttpStatusCode.InternalServerError,
//            Source = Errorsource.ADLAPI,
//            Description = ex.GetMessage()
//        };
//        _serilogger.WriteLog(Severity.Error, traceId, agentId, this.GetType().ToString(), CommonMessage.COMMERCE_TERMINALSTORE, LogFormat.JSON, LogType.Exception, CommonMessage.COMMERCE_ENDTERMINALSTORE, response, LogDataModel.Error, Enum.GetName(Functionality.GetTerminalStores.GetType(), Functionality.GetTerminalStores));
//    }
//    return response;
//}