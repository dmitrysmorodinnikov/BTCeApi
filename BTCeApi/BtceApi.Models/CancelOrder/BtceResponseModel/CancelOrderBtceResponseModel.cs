namespace BtceApi.Models.CancelOrder.BtceResponseModel
{
    public class CancelOrderBtceResponseModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public CancelOrderBtceReturn Return { get; set; }
    }

    public class CancelOrderBtceReturn
    {
        public int Order_id { get; set; }
        public FundInfo Funds { get; set; }
    }
}
