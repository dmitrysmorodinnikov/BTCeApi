using System.Collections.Generic;

namespace BtceApi.Models.TradeApiModels.TradeHistory.BtceResponseModel
{
    public class TradeHistoryBtceResponseModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public Dictionary<string, BtceTrade> Return { get; set; } 
    }

    public class BtceTrade
    {
        public string Pair { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; }
        public int Order_id { get; set; }
        public bool Is_Your_Order { get; set; }
        public string Timestamp { get; set; }
    }
}
