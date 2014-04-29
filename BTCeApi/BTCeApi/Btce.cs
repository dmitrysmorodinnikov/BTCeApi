using BtceApi.Models.ActiveOrders.Model;
using BtceApi.Models.CancelOrder.Model;
using BtceApi.Models.GetInfo.Model;
using BtceApi.Models.Trade.Model;
using BtceApi.Models.TradeHistory.Model;
using BtceApi.Models.TransactionsHistory.Model;
using BtceApi.Services;


namespace BTCeApi
{
    public class Btce
    {
        private readonly IBtceService _btceService;

        public Btce(string key, string secret)
        {
            _btceService = new BtceService(key,secret);
        }

        /// <summary>
        /// Provide information about user's current balance,API key privileges,the number of transactions, the number of open orders and server time
        /// </summary>
        /// <returns>
        /// Returns information about user's current balance,API key privileges,the number of transactions, the number of open orders and server time
        /// </returns>
        public GetInfoModel GetInfo()
        {
            return _btceService.GetInfo();
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
            return _btceService.ActiveOrders(pair.ToString());
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
            return _btceService.TransactionsHistory(from, count, fromId, endId, sort.ToString(), since, end);
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
            return _btceService.TradeHistory(from, count, fromId, endId, sort.ToString(), since, end, pair.ToString());
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
            return _btceService.Trade(pair.ToString(), operationType.ToString(), rate, amount);
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
            return _btceService.CancelOrder(orderId);
        }
    }
}
