using BtceApi.Models;
using BtceApi.Models.TradeApiModels.ActiveOrders.Model;
using BtceApi.Models.TradeApiModels.CancelOrder.Model;
using BtceApi.Models.TradeApiModels.GetInfo.Model;
using BtceApi.Models.TradeApiModels.Trade.Model;
using BtceApi.Models.TradeApiModels.TradeHistory.Model;
using BtceApi.Models.TradeApiModels.TransactionsHistory.Model;
using BtceApi.Services;


namespace BTCeApi
{
    public class Btce
    {
        private readonly IBtceTradeApiService _btceTradeApiService;
        private readonly IBtcePublicApiService _btcePublicApiService;
        
        public Btce(string key, string secret)
        {
            _btceTradeApiService = new BtceTradeApiService(key,secret);
            _btcePublicApiService = new BtcePublicApiService(key,secret);
        }

        public IBtcePublicApiService BtcUsd
        {
            get
            {
                _btcePublicApiService.CurrencyPair = CurrencyPair.BtcUsd;
                return _btcePublicApiService;
            }
        }

        public IBtcePublicApiService BtcEur
        {
            get
            {
                _btcePublicApiService.CurrencyPair = CurrencyPair.BtcEur;
                return _btcePublicApiService;
            }
        }

        public IBtcePublicApiService BtcRur
        {
            get
            {
                _btcePublicApiService.CurrencyPair = CurrencyPair.BtcRur;
                return _btcePublicApiService;
            }
        }

        public IBtcePublicApiService LtcBtc
        {
            get
            {
                _btcePublicApiService.CurrencyPair = CurrencyPair.LtcBtc;
                return _btcePublicApiService;
            }
        }

        public IBtcePublicApiService LtcUsd
        {
            get
            {
                _btcePublicApiService.CurrencyPair = CurrencyPair.LtcUsd;
                return _btcePublicApiService;
            }
        }

        public IBtcePublicApiService LtcRur
        {
            get
            {
                _btcePublicApiService.CurrencyPair = CurrencyPair.LtcRur;
                return _btcePublicApiService;
            }
        }

        public IBtcePublicApiService NmcBtc
        {
            get
            {
                _btcePublicApiService.CurrencyPair = CurrencyPair.NmcBtc;
                return _btcePublicApiService;
            }
        }

        public IBtcePublicApiService UsdRur
        {
            get
            {
                _btcePublicApiService.CurrencyPair = CurrencyPair.UsdRur;
                return _btcePublicApiService;
            }
        }

        public IBtcePublicApiService EurUsd
        {
            get
            {
                _btcePublicApiService.CurrencyPair = CurrencyPair.EurUsd;
                return _btcePublicApiService;
            }
        }
        /// <summary>
        /// Provide information about user's current balance,API key privileges,the number of transactions, the number of open orders and server time
        /// </summary>
        /// <returns>
        /// Returns information about user's current balance,API key privileges,the number of transactions, the number of open orders and server time
        /// </returns>
        public GetInfoModel GetInfo()
        {
            return _btceTradeApiService.GetInfo();
        }

        /// <summary>
        /// Provide information about your open orders
        /// </summary>
        /// <param name="pair">The pair to display the orders</param>
        /// <returns>
        /// Returns your open orders
        /// </returns>
        public ActiveOrdersModel ActiveOrders(Pair pair = Pair.All)
        {
            return _btceTradeApiService.ActiveOrders(pair.ToString());
        }

        /// <summary>
        /// Provide transactions history
        /// </summary>
        /// <param name="from">The ID of the transaction to start displaying with</param>
        /// <param name="count">The number of transactions for displaying</param>
        /// <param name="fromId">The ID of the transaction to start displaying with</param>
        /// <param name="endId">The ID of the transaction to finish displaying with</param>
        /// <param name="sort">Sorting</param>
        /// <param name="since">When to start displaying</param>
        /// <param name="end">When to finish displaying</param>
        /// <returns>
        /// Returns the transactions history
        /// </returns>
        public TransactionsHistoryModel TransactionsHistory(int? from = null, int? count = null, int? fromId = null, int? endId = null, Sort sort = Sort.DESC, string since = null, string end = null)
        {
            return _btceTradeApiService.TransactionsHistory(from, count, fromId, endId, sort.ToString(), since, end);
        }

        /// <summary>
        /// Provide trade history
        /// </summary>
        /// <param name="from">The ID of the transaction to start displaying with</param>
        /// <param name="count">The number of transactions for displaying</param>
        /// <param name="fromId">The ID of the transaction to start displaying with</param>
        /// <param name="endId">The ID of the transaction to finish displaying with</param>
        /// <param name="sort">Sorting</param>
        /// <param name="since">When to start displaying</param>
        /// <param name="end">When to finish displaying</param>
        /// <param name="pair">The pair to show the transactions</param>
        /// <returns>
        /// Returns the trade history
        /// </returns>
        public TradeHistoryModel TradeHistory(int? from = null, int? count = null, int? fromId = null, int? endId = null, Sort sort = Sort.DESC, string since = null, string end = null, Pair pair = Pair.All)
        {
            return _btceTradeApiService.TradeHistory(from, count, fromId, endId, sort.ToString(), since, end, pair.ToString());
        }

        /// <summary>
        /// Trading is done according to this method
        /// </summary>
        /// <param name="pair">Pair</param>
        /// <param name="operationType">The transaction type</param>
        /// <param name="rate">The rate to buy/sell</param>
        /// <param name="amount">The amount which is necessary to buy/sell</param>
        /// <returns>
        /// The result of the trade
        /// </returns>
        public TradeModel Trade(Pair pair,OperationType operationType, double rate, double amount)
        {
            return _btceTradeApiService.Trade(pair.ToString(), operationType.ToString(), rate, amount);
        }

        /// <summary>
        /// Cancellation of the order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>
        /// Returns confirmation of cancelling the order and funds information
        /// </returns>
        public CancelOrderModel CancelOrder(int orderId)
        {
            return _btceTradeApiService.CancelOrder(orderId);
        }
    }
}
