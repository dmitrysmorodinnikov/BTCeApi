using System.IO;
using BtceApi.Models.Trade.BtceResponseModel;
using BtceApi.Models.Trade.Model;

namespace BtceApi.Services.Trade
{
    public class TradeService
    {
        private readonly BtceApiHttpClient _httpClient;

        public TradeService(string key, string secret)
        {
            _httpClient = new BtceApiHttpClient(key,secret);
        }

        public TradeModel Trade(string pair,string type,double rate,double amount)
        {
            var response = _httpClient.SendRequest(ArgsDictionaryService.TradeDictionary(pair,type,rate,amount));
            string responseStr = string.Empty;
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    responseStr = new StreamReader(responseStream).ReadToEnd();
            }
            var btceResponseModel = GetTradeBtceResponseModel(responseStr);
            var tradeModel = ConvertToTradeModel(btceResponseModel);
            return tradeModel;
        }

        private TradeModel ConvertToTradeModel(TradeBtceResponseModel tradeBtceResponseModel)
        {
            var tradeModel = new TradeModel()
            {
                Received = tradeBtceResponseModel.Return.Received,
                Remains = tradeBtceResponseModel.Return.Remains,
                OrderId = tradeBtceResponseModel.Return.Order_id,
                FundInfo = tradeBtceResponseModel.Return.Funds
            };
            
            return tradeModel;
        }

        private TradeBtceResponseModel GetTradeBtceResponseModel(string responseStr)
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<TradeBtceResponseModel>(responseStr);
        }
    }
}
