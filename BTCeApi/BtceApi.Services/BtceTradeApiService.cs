using System.Collections.Generic;
using BtceApi.Models;
using BtceApi.Models.TradeApiModels.ActiveOrders.BtceResponseModel;
using BtceApi.Models.TradeApiModels.ActiveOrders.Model;
using BtceApi.Models.TradeApiModels.CancelOrder.BtceResponseModel;
using BtceApi.Models.TradeApiModels.CancelOrder.Model;
using BtceApi.Models.TradeApiModels.GetInfo.BtceResponseModel;
using BtceApi.Models.TradeApiModels.GetInfo.Model;
using BtceApi.Models.TradeApiModels.Trade.BtceResponseModel;
using BtceApi.Models.TradeApiModels.Trade.Model;
using BtceApi.Models.TradeApiModels.TradeHistory.BtceResponseModel;
using BtceApi.Models.TradeApiModels.TradeHistory.Model;
using BtceApi.Models.TradeApiModels.TransactionsHistory.BtceResponseModel;
using BtceApi.Models.TradeApiModels.TransactionsHistory.Model;

namespace BtceApi.Services
{
    public class BtceTradeApiService : IBtceTradeApiService
    {
        private readonly BtceApiHttpClient _httpClient;
        
        public BtceTradeApiService(string key, string secret)
        {
            _httpClient = new BtceApiHttpClient(key,secret);
        }

        public GetInfoModel GetInfo()
        {
            var btceApiResponseModel = _httpClient.SendPostRequestToTradeApi<GetInfoBtceResponseModel>(ArgsDictionaryService.GetInfoArgsDictionary());
            var getInfoModel = BtceModelsConverter.ConvertToGetInfoModel(btceApiResponseModel);
            return getInfoModel;
        }

        public ActiveOrdersModel ActiveOrders(string pair)
        {
            var btceApiResponseModel = _httpClient.SendPostRequestToTradeApi<ActiveOrdersBtceResponseModel>(ArgsDictionaryService.ActiveOrdersArgsDictionary(pair));
            var activeOrdersModel = BtceModelsConverter.ConvertToActiveOrdersModel(btceApiResponseModel);
            return activeOrdersModel;
        }

        public CancelOrderModel CancelOrder(int orderId)
        {
            var btceApiResponseModel = _httpClient.SendPostRequestToTradeApi<CancelOrderBtceResponseModel>(ArgsDictionaryService.CancelOrderDictionary(orderId));
            var cancelOrderModel = BtceModelsConverter.ConvertToCancelOrderModel(btceApiResponseModel);
            return cancelOrderModel;
        }

        public TradeModel Trade(string pair, string type, double rate, double amount)
        {
            var btceApiResponseModel = _httpClient.SendPostRequestToTradeApi<TradeBtceResponseModel>(ArgsDictionaryService.TradeDictionary(pair,type,rate,amount));
            var tradeModel = BtceModelsConverter.ConvertToTradeModel(btceApiResponseModel);
            return tradeModel;
        }

        public TradeHistoryModel TradeHistory(int? from, int? count, int? fromId, int? endId, string order, string since, string end, string pair)
        {
            var btceApiResponseModel = _httpClient.SendPostRequestToTradeApi<TradeHistoryBtceResponseModel>(ArgsDictionaryService.TradeHistoryDictionary(from,count,fromId,endId,order,since,end,pair));
            var tradeHistoryModel = BtceModelsConverter.ConvertToTradeHistoryModel(btceApiResponseModel);
            return tradeHistoryModel;
        }

        public TransactionsHistoryModel TransactionsHistory(int? from, int? count, int? fromId, int? endId, string order, string since, string end)
        {
            var btceApiResponseModel = _httpClient.SendPostRequestToTradeApi<TransactionsHistoryBtceResponseModel>(ArgsDictionaryService.TransactionsHistoryDictionary(from, count, fromId, endId, order, since, end));
            var transactionsHistoryModel = BtceModelsConverter.ConvertToTransactionsHistoryModel(btceApiResponseModel);
            return transactionsHistoryModel;
        }
    }
}
