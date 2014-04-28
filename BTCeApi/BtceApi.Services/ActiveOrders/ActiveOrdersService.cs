using System.Collections.ObjectModel;
using System.IO;
using BtceApi.Models.ActiveOrders.BtceResponseModel;
using BtceApi.Models.ActiveOrders.Model;

namespace BtceApi.Services.ActiveOrders
{
    public class ActiveOrdersService
    {
        private readonly BtceApiHttpClient _httpClient;

        public ActiveOrdersService(string key, string secret)
        {
            _httpClient = new BtceApiHttpClient(key,secret);
        }

        public ActiveOrdersModel ActiveOrders(string pair)
        {
            var response = _httpClient.SendRequest(ArgsDictionaryService.ActiveOrdersArgsDictionary(pair));
            string responseStr = string.Empty;
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    responseStr = new StreamReader(responseStream).ReadToEnd();
            }
            var activeOrdersBtceResponseModel = GetActiveOrdersBtceResponseModel(responseStr);
            var activeOrdersModel = ConvertToActiveOrdersModel(activeOrdersBtceResponseModel);
            return activeOrdersModel;
        }

        private ActiveOrdersModel ConvertToActiveOrdersModel(ActiveOrdersBtceResponseModel activeOrdersBtceResponseModel)
        {
            var activeOrdersModel = new ActiveOrdersModel();
            activeOrdersModel.ActiveOrders = new Collection<Order>();
            foreach (var order in activeOrdersBtceResponseModel.Return)
            {
                activeOrdersModel.ActiveOrders.Add(new Order
                                                        {
                                                            OrderNumber = order.Key,
                                                            Amount = order.Value.Amount,
                                                            Pair = order.Value.Pair,
                                                            Rate = order.Value.Rate,
                                                            Status = order.Value.Status,
                                                            TimeStampCreated = order.Value.TimeStamp_Created,
                                                            Type = order.Value.Type
                                                        }); 
            }
            return activeOrdersModel;
        }

        private ActiveOrdersBtceResponseModel GetActiveOrdersBtceResponseModel(string responseStr)
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<ActiveOrdersBtceResponseModel>(responseStr);
        }
    }
}
