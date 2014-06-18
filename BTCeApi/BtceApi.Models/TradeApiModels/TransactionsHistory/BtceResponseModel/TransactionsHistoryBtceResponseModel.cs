using System.Collections.Generic;

namespace BtceApi.Models.TradeApiModels.TransactionsHistory.BtceResponseModel
{
    public class TransactionsHistoryBtceResponseModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public Dictionary<string, BtceResponseTransaction> Return { get; set; }
    }

    public class BtceResponseTransaction
    {
        public int Type { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Desc { get; set; }
        public int Status { get; set; }
        public string Timestamp { get; set; }
    }
}
