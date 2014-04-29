namespace BtceApi.Models.Trade.BtceResponseModel
{
    public class TradeBtceResponseModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public BtceResponseTradeItem Return { get; set; }
    }

    public class BtceResponseTradeItem
    {
        public double Received { get; set; }
        public double Remains { get; set; }
        public int Order_id { get; set; }
        public FundInfo Funds { get; set; }
    }
}
