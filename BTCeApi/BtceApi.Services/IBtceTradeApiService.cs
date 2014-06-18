using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BtceApi.Models;
using BtceApi.Models.TradeApiModels.ActiveOrders.Model;
using BtceApi.Models.TradeApiModels.CancelOrder.Model;
using BtceApi.Models.TradeApiModels.GetInfo.Model;
using BtceApi.Models.TradeApiModels.Trade.Model;
using BtceApi.Models.TradeApiModels.TradeHistory.Model;
using BtceApi.Models.TradeApiModels.TransactionsHistory.Model;

namespace BtceApi.Services
{
    public interface IBtceTradeApiService
    {
        GetInfoModel GetInfo();
        ActiveOrdersModel ActiveOrders(string pair);
        CancelOrderModel CancelOrder(int orderId);
        TradeModel Trade(string pair, string type, double rate, double amount);
        TradeHistoryModel TradeHistory(int? from, int? count, int? fromId, int? endId, string order, string since,string end, string pair);
        TransactionsHistoryModel TransactionsHistory(int? from, int? count, int? fromId, int? endId, string order,string since, string end);
    }
}
