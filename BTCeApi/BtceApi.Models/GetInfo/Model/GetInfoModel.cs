namespace BtceApi.Models.GetInfo.Model
{
    public class GetInfoModel
    {
        public FundInfo FundInfo { get; set; }
        public RightInfo RightsInfo { get; set; }
        public string ServerTime { get; set; }
        public int OpenOrders { get; set; }
        public int TransactionCount { get; set; }
    }
}
