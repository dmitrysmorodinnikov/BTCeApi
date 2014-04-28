using BtceApi.Models.ActiveOrders.Model;
using BtceApi.Models.GetInfo.Model;
using BtceApi.Models.Trade.Model;
using BtceApi.Models.TradeHistory.Model;
using BtceApi.Models.TransactionsHistory.Model;
using BtceApi.Services.ActiveOrders;
using BtceApi.Services.GetInfo;
using BtceApi.Services.Trade;
using BtceApi.Services.TradeHistory;
using BtceApi.Services.TransactionsHistory;


namespace BTCeApi
{
    public class Btce
    {
        readonly string _key;
        private readonly string _secret;

        public Btce(string key, string secret)
        {
            _key = key;
            _secret = secret;
        }

        public GetInfoModel GetInfo()
        {
            var getInfoModel = new GetInfoService(_key,_secret).GetInfo();
            return getInfoModel;
        }

        public ActiveOrdersModel ActiveOrders(Pair pair = Pair.All)
        {
            var activeOrders = new ActiveOrdersService(_key,_secret).ActiveOrders(pair.ToString().ToLower());
            return activeOrders;
        }

        public TransactionsHistoryModel TransactionsHistory(int? from = null, int? count = null, int? fromId = null,int? endId = null, Sort sort = Sort.DESC, string since = null, string end = null)
        {
            var transactionsHistory = new TransactionsHistoryService(_key,_secret).TransactionsHistory(from,count,fromId,endId,sort.ToString(),since,end);
            return transactionsHistory;
        }

        public TradeHistoryModel TradeHistory(int? from = null, int? count = null, int? fromId = null, int? endId = null, Sort sort = Sort.DESC, string since = null, string end = null,Pair pair = Pair.All)
        {
            var transactionsHistory = new TradeHistoryService(_key, _secret).TradeHistory(from,count,fromId,endId,sort.ToString(),since,end,pair.ToString());
            return transactionsHistory;
        }

        public TradeModel Trade(Pair pair,OperationType operationType,double rate,double amount)
        {
            var trade = new TradeService(_key, _secret).Trade(pair.ToString(), operationType.ToString(), rate, amount);
            return trade;
        }
    }
}
