using System.Collections.Generic;

namespace BtceApi.Models.TradeApiModels.ActiveOrders.BtceResponseModel
{
    public class ActiveOrdersBtceResponseModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public Dictionary<string, BtceResponseOrder> Return { get; set; }
    }

    public class BtceResponseOrder
    {
        public string Pair { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; }
        public string TimeStamp_Created { get; set; }
        public int Status { get; set; }
    }
}
