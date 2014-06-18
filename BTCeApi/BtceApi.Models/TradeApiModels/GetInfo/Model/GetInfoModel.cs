namespace BtceApi.Models.TradeApiModels.GetInfo.Model
{
    public class GetInfoModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public FundInfo FundInfo { get; set; }
        public RightInfo RightsInfo { get; set; }
        public string ServerTime { get; set; }
        public int OpenOrders { get; set; }
        public int TransactionCount { get; set; }
    }
}
