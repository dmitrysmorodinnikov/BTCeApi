using System;
using System.Collections.Generic;

namespace BtceApi.Services
{
   internal static class ArgsDictionaryService
    {
       internal static Dictionary<string,string> GetInfoArgsDictionary()
       {
          var argsDictionary = new Dictionary<string, string> {{"method", "getInfo"}, {"nonce", GetNonce()}};
           return argsDictionary;
       }

       internal static Dictionary<string, string> ActiveOrdersArgsDictionary(string pair)
       {
           var argsDictionary = new Dictionary<string, string> {{"method", "ActiveOrders"}, {"nonce", GetNonce()}};
           if(pair != "All")
               argsDictionary.Add("pair", pair);
           return argsDictionary;
       }

       internal static Dictionary<string, string> TransactionsHistoryDictionary(int? from, int? count, int? fromId,int? endId, string order, string since, string end)
       {
           var argsDictionary = new Dictionary<string, string> { { "method", "TransHistory" }, { "nonce", GetNonce()}, {"order",order}};
           if(from != null)
               argsDictionary.Add("from",from.ToString());
           if(count != null)
               argsDictionary.Add("count",count.ToString());
           if (fromId != null)
               argsDictionary.Add("from_id", fromId.ToString());
           if (endId != null)
               argsDictionary.Add("end_id", endId.ToString());
           if (!string.IsNullOrEmpty(since))
               argsDictionary.Add("since", since);
           if (!string.IsNullOrEmpty(end))
               argsDictionary.Add("end", end);

           return argsDictionary;
       }

       public static Dictionary<string, string> TradeHistoryDictionary(int? from, int? count, int? fromId, int? endId, string order, string since, string end, string pair)
       {
           var argsDictionary = new Dictionary<string, string> { { "method", "TradeHistory" }, { "nonce", GetNonce() }, { "order", order } };
           if (from != null)
               argsDictionary.Add("from", from.ToString());
           if (count != null)
               argsDictionary.Add("count", count.ToString());
           if (fromId != null)
               argsDictionary.Add("from_id", fromId.ToString());
           if (endId != null)
               argsDictionary.Add("end_id", endId.ToString());
           if (!string.IsNullOrEmpty(since))
               argsDictionary.Add("since", since);
           if (!string.IsNullOrEmpty(end))
               argsDictionary.Add("end", end);
           if (pair != "All")
               argsDictionary.Add("pair", pair);

           return argsDictionary;
       }

       public static Dictionary<string, string> TradeDictionary(string pair, string type, double rate, double amount)
       {
           return new Dictionary<string, string>
           {
               {"method", "Trade"},
               {"nonce", GetNonce()},
               {"pair", pair},
               {"type", type},
               {"rate", rate.ToString()},
               {"amount", amount.ToString()}
           };
       }

       public static Dictionary<string, string> CancelOrderDictionary(int orderId)
       {
           return new Dictionary<string, string>
           {
               {"method", "CancelOrder"},
               {"nonce", GetNonce()},
               {"order_id", orderId.ToString()}
           };
       }

       private static string GetNonce()
       {
           var currDate = DateTime.UtcNow;
           var res = (currDate - new DateTime(1969, 1, 1, 0, 0, 0, 0));
           return ((int)res.TotalSeconds).ToString();
       }
    }
}
