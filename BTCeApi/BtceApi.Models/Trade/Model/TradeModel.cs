namespace BtceApi.Models.Trade.Model
{
    public class TradeModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public double Received { get; set; }
        public double Remains { get; set; }
        public int OrderId { get; set; }
        public FundInfo FundInfo { get; set; }
    }
}
