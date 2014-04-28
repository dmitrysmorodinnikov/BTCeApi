namespace BtceApi.Models.Trade.Model
{
    public class TradeModel
    {
        public double Received { get; set; }
        public double Remains { get; set; }
        public int OrderId { get; set; }
        public FundInfo FundInfo { get; set; }
    }
}
