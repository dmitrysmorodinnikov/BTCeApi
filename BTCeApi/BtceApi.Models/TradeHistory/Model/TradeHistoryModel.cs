using System.Collections.Generic;

namespace BtceApi.Models.TradeHistory.Model
{
    public class TradeHistoryModel
    {
        public ICollection<TradeInfo> Trades { get; set; } 
    }

    public class TradeInfo
    {
        public string Number { get; set; }
        public string Pair { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; }
        public int OrderId { get; set; }
        public bool IsYourOrder { get; set; }
        public string Timestamp { get; set; }
    }
}
