using BtceApi.Models.ActiveOrders.BtceResponseModel;
using BtceApi.Models.ActiveOrders.Model;
using BtceApi.Models.CancelOrder.BtceResponseModel;
using BtceApi.Models.CancelOrder.Model;
using BtceApi.Models.GetInfo.BtceResponseModel;
using BtceApi.Models.GetInfo.Model;
using BtceApi.Models.Trade.BtceResponseModel;
using BtceApi.Models.Trade.Model;
using BtceApi.Models.TradeHistory.BtceResponseModel;
using BtceApi.Models.TradeHistory.Model;
using BtceApi.Models.TransactionsHistory.BtceResponseModel;
using BtceApi.Models.TransactionsHistory.Model;

namespace BtceApi.Services
{
    public class BtceService : IBtceService
    {
        private readonly BtceApiHttpClient _httpClient;

        public BtceService(string key, string secret)
        {
            _httpClient = new BtceApiHttpClient(key,secret);
        }

        public GetInfoModel GetInfo()
        {
            var btceApiResponseModel = _httpClient.SendRequest<GetInfoBtceResponseModel>(ArgsDictionaryService.GetInfoArgsDictionary());
            var getInfoModel = BtceModelsConverter.ConvertToGetInfoModel(btceApiResponseModel);
            return getInfoModel;
        }

        public ActiveOrdersModel ActiveOrders(string pair)
        {
            var btceApiResponseModel = _httpClient.SendRequest<ActiveOrdersBtceResponseModel>(ArgsDictionaryService.ActiveOrdersArgsDictionary(pair));
            var activeOrdersModel = BtceModelsConverter.ConvertToActiveOrdersModel(btceApiResponseModel);
            return activeOrdersModel;
        }

        public CancelOrderModel CancelOrder(int orderId)
        {
            var btceApiResponseModel = _httpClient.SendRequest<CancelOrderBtceResponseModel>(ArgsDictionaryService.CancelOrderDictionary(orderId));
            var cancelOrderModel = BtceModelsConverter.ConvertToCancelOrderModel(btceApiResponseModel);
            return cancelOrderModel;
        }

        public TradeModel Trade(string pair, string type, double rate, double amount)
        {
            var btceApiResponseModel = _httpClient.SendRequest<TradeBtceResponseModel>(ArgsDictionaryService.TradeDictionary(pair,type,rate,amount));
            var tradeModel = BtceModelsConverter.ConvertToTradeModel(btceApiResponseModel);
            return tradeModel;
        }

        public TradeHistoryModel TradeHistory(int? from, int? count, int? fromId, int? endId, string order, string since, string end, string pair)
        {
            var btceApiResponseModel = _httpClient.SendRequest<TradeHistoryBtceResponseModel>(ArgsDictionaryService.TradeHistoryDictionary(from,count,fromId,endId,order,since,end,pair));
            var tradeHistoryModel = BtceModelsConverter.ConvertToTradeHistoryModel(btceApiResponseModel);
            return tradeHistoryModel;
        }

        public TransactionsHistoryModel TransactionsHistory(int? from, int? count, int? fromId, int? endId, string order, string since, string end)
        {
            var btceApiResponseModel = _httpClient.SendRequest<TransactionsHistoryBtceResponseModel>(ArgsDictionaryService.TransactionsHistoryDictionary(from, count, fromId, endId, order, since, end));
            var transactionsHistoryModel = BtceModelsConverter.ConvertToTransactionsHistoryModel(btceApiResponseModel);
            return transactionsHistoryModel;
        }
    }
}
