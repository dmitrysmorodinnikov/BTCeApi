using System.IO;
using BtceApi.Models.GetInfo.BtceResponseModel;
using BtceApi.Models.GetInfo.Model;

namespace BtceApi.Services.GetInfo
{
    public class GetInfoService
    {
        private readonly BtceApiHttpClient _httpClient;

        public GetInfoService(string key, string secret)
        {
            _httpClient = new BtceApiHttpClient(key,secret);
        }

        public GetInfoModel GetInfo()
        {
            var response = _httpClient.SendRequest(ArgsDictionaryService.GetInfoArgsDictionary());
            string responseStr = string.Empty;
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    responseStr = new StreamReader(responseStream).ReadToEnd();
            }
            var btceApiResponseModel = GetInfoBtceResponseModel(responseStr);
            var getInfoModel = ConvertToGetInfoModel(btceApiResponseModel);
            return getInfoModel;
        }

        private GetInfoModel ConvertToGetInfoModel(GetInfoBtceResponseModel getInfoBtceResponseModel)
        {
           return new GetInfoModel()
            {
                ServerTime = getInfoBtceResponseModel.Return.Server_Time,
                TransactionCount = getInfoBtceResponseModel.Return.Transaction_Count,
                OpenOrders = getInfoBtceResponseModel.Return.Open_Orders,
                FundInfo = getInfoBtceResponseModel.Return.Funds,
                RightsInfo = getInfoBtceResponseModel.Return.Rights
            };
        }

        private GetInfoBtceResponseModel GetInfoBtceResponseModel(string responseStr)
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<GetInfoBtceResponseModel>(responseStr);
        }
    }
}
