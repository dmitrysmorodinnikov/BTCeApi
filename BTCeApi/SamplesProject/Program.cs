using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTCeApi;
using BtceApi.Models;
using ServiceStack.Text;
using BtceApi = BTCeApi.Btce;


namespace SamplesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiSecret = "Your_Secret";
            var apiKey = "Your_Key";
            var btce = new BTCeApi.Btce(apiKey,apiSecret);
            //var info = btce.GetInfo();

            //var activeOrders = btce.ActiveOrders(Pair.Btc_Usd);

            //var transactionsHistory = btce.TransactionsHistory();

           // var tradeHistory = btce.TradeHistory();

            //var res = transactionsHistory;
        }
    }
}
