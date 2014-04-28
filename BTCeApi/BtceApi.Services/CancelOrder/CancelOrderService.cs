using System.IO;
using BtceApi.Models.CancelOrder.BtceResponseModel;
using BtceApi.Models.CancelOrder.Model;

namespace BtceApi.Services.CancelOrder
{
    public class CancelOrderService
    {
        private readonly BtceApiHttpClient _httpClient;

        public CancelOrderService(string key, string secret)
        {
            _httpClient = new BtceApiHttpClient(key,secret);
        }

        public CancelOrderModel CancelOrder(int orderId)
        {
            var response = _httpClient.SendRequest(ArgsDictionaryService.CancelOrderDictionary(orderId));
            string responseStr = string.Empty;
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    responseStr = new StreamReader(responseStream).ReadToEnd();
            }
            var btceResponseModel = GetCancelOrderBtceResponseModel(responseStr);
            var cancelOrderModel = ConvertToCancelOrderModel(btceResponseModel);
            return cancelOrderModel;
        }

        private CancelOrderModel ConvertToCancelOrderModel(CancelOrderBtceResponseModel cancelOrderBtceResponseModel)
        {
            var cancelOrderModel = new CancelOrderModel()
            {
                OrderId = cancelOrderBtceResponseModel.Return.Order_id,
                FundInfo = cancelOrderBtceResponseModel.Return.Funds
            };
            
            return cancelOrderModel;
        }

        private CancelOrderBtceResponseModel GetCancelOrderBtceResponseModel(string responseStr)
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<CancelOrderBtceResponseModel>(responseStr);
        }
    }
}
