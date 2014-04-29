using System.Collections.ObjectModel;
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
    internal static class BtceModelsConverter
    {
        internal static GetInfoModel ConvertToGetInfoModel(GetInfoBtceResponseModel getInfoBtceResponseModel)
        {
            if (!getInfoBtceResponseModel.Success)
            {
                return new GetInfoModel
                {
                    Success = false,
                    ErrorMessage = getInfoBtceResponseModel.Error
                };
            }

            return new GetInfoModel
            {
                Success = true,
                ServerTime = getInfoBtceResponseModel.Return.Server_Time,
                TransactionCount = getInfoBtceResponseModel.Return.Transaction_Count,
                OpenOrders = getInfoBtceResponseModel.Return.Open_Orders,
                FundInfo = getInfoBtceResponseModel.Return.Funds,
                RightsInfo = getInfoBtceResponseModel.Return.Rights
            };
        }

        internal static ActiveOrdersModel ConvertToActiveOrdersModel(ActiveOrdersBtceResponseModel activeOrdersBtceResponseModel)
        {
            if (!activeOrdersBtceResponseModel.Success)
            {
                return new ActiveOrdersModel()
                {
                    Success = activeOrdersBtceResponseModel.Success,
                    ErrorMessage = activeOrdersBtceResponseModel.Error
                };
            }
            var activeOrdersModel = new ActiveOrdersModel() { Success = true };
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

        internal static CancelOrderModel ConvertToCancelOrderModel(CancelOrderBtceResponseModel cancelOrderBtceResponseModel)
        {
            if (!cancelOrderBtceResponseModel.Success)
            {
                return new CancelOrderModel()
                {
                    Success = false,
                    ErrorMessage = cancelOrderBtceResponseModel.Error
                };
            }
            var cancelOrderModel = new CancelOrderModel()
            {
                Success = true,
                OrderId = cancelOrderBtceResponseModel.Return.Order_id,
                FundInfo = cancelOrderBtceResponseModel.Return.Funds
            };

            return cancelOrderModel;
        }

        internal static TradeModel ConvertToTradeModel(TradeBtceResponseModel tradeBtceResponseModel)
        {
            if (!tradeBtceResponseModel.Success)
            {
                return new TradeModel()
                {
                    Success = false,
                    ErrorMessage = tradeBtceResponseModel.Error
                };
            }
            var tradeModel = new TradeModel()
            {
                Success = true,
                Received = tradeBtceResponseModel.Return.Received,
                Remains = tradeBtceResponseModel.Return.Remains,
                OrderId = tradeBtceResponseModel.Return.Order_id,
                FundInfo = tradeBtceResponseModel.Return.Funds
            };

            return tradeModel;
        }

        internal static TradeHistoryModel ConvertToTradeHistoryModel(TradeHistoryBtceResponseModel tradeHistoryBtceResponseModel)
        {
            if (!tradeHistoryBtceResponseModel.Success)
            {
                return new TradeHistoryModel()
                {
                    Success = false,
                    ErrorMessage = tradeHistoryBtceResponseModel.Error
                };
            }
            var tradeHistoryModel = new TradeHistoryModel() { Success = true, Trades = new Collection<TradeInfo>() };
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

        internal static TransactionsHistoryModel ConvertToTransactionsHistoryModel(TransactionsHistoryBtceResponseModel transactionsHistoryBtceResponseModel)
        {
            if (!transactionsHistoryBtceResponseModel.Success)
            {
                return new TransactionsHistoryModel()
                {
                    Success = false,
                    ErrorMessage = transactionsHistoryBtceResponseModel.Error
                };
            }
            var transactionsHistoryModel = new TransactionsHistoryModel() { Success = true, Transactions = new Collection<Transaction>() };
            foreach (var btceResponseTransaction in transactionsHistoryBtceResponseModel.Return)
            {
                transactionsHistoryModel.Transactions.Add(new Transaction()
                {
                    Amount = btceResponseTransaction.Value.Amount,
                    Currency = btceResponseTransaction.Value.Currency,
                    Desc = btceResponseTransaction.Value.Desc,
                    Number = btceResponseTransaction.Key,
                    Status = btceResponseTransaction.Value.Status,
                    TimeStamp = btceResponseTransaction.Value.Timestamp,
                    Type = btceResponseTransaction.Value.Type
                });
            }
            return transactionsHistoryModel;
        }
    }
}
