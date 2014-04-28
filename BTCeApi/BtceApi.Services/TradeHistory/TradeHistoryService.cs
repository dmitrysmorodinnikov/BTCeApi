using System.Collections.ObjectModel;
using System.IO;
using BtceApi.Models.TradeHistory.BtceResponseModel;
using BtceApi.Models.TradeHistory.Model;

namespace BtceApi.Services.TradeHistory
{
    public class TradeHistoryService
    {
        private readonly BtceApiHttpClient _httpClient;

        public TradeHistoryService(string key, string secret)
        {
            _httpClient = new BtceApiHttpClient(key,secret);
        }

        public TradeHistoryModel TradeHistory(int? from, int? count, int? fromId, int? endId, string order, string since, string end,string pair)
        {
            var response = _httpClient.SendRequest(ArgsDictionaryService.TradeHistoryDictionary(from,count,fromId,endId,order,since,end,pair));
            string responseStr = string.Empty;
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    responseStr = new StreamReader(responseStream).ReadToEnd();
            }
            var btceResponseModel = GetTradeHistoryBtceResponseModel(responseStr);
            var tradeHistoryModel = ConvertToTradeHistoryModel(btceResponseModel);
            return tradeHistoryModel;
        }

        private TradeHistoryModel ConvertToTradeHistoryModel(TradeHistoryBtceResponseModel tradeHistoryBtceResponseModel)
        {
            var tradeHistoryModel = new TradeHistoryModel() {Trades = new Collection<TradeInfo>()};
            foreach (var btceResponseTrade in tradeHistoryBtceResponseModel.Return)
            {
                tradeHistoryModel.Trades.Add(new TradeInfo()
                {
                    Number = btceResponseTrade.Key,
                    Amount = btceResponseTrade.Value.Amount,
                    Timestamp = btceResponseTrade.Value.Timestamp,
                    Type = btceResponseTrade.Value.Type,
                    IsYourOrder = btceResponseTrade.Value.Is_Your_Order,
                    OrderId = btceResponseTrade.Value.Order_id,
                    Pair = btceResponseTrade.Value.Pair,
                    Rate = btceResponseTrade.Value.Rate
                });
            }
            return tradeHistoryModel;
        }

        private TradeHistoryBtceResponseModel GetTradeHistoryBtceResponseModel(string responseStr)
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<TradeHistoryBtceResponseModel>(responseStr);
        }
    }
}
