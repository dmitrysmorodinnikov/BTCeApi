using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BtceApi.Models.ActiveOrders.Model;
using BtceApi.Models.CancelOrder.Model;
using BtceApi.Models.GetInfo.Model;
using BtceApi.Models.Trade.Model;
using BtceApi.Models.TradeHistory.Model;
using BtceApi.Models.TransactionsHistory.Model;

namespace BtceApi.Services
{
    public interface IBtceService
    {
        GetInfoModel GetInfo();
        ActiveOrdersModel ActiveOrders(string pair);
        CancelOrderModel CancelOrder(int orderId);
        TradeModel Trade(string pair, string type, double rate, double amount);
        TradeHistoryModel TradeHistory(int? from, int? count, int? fromId, int? endId, string order, string since,string end, string pair);
        TransactionsHistoryModel TransactionsHistory(int? from, int? count, int? fromId, int? endId, string order,string since, string end);
    }
}
