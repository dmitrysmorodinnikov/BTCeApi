namespace BtceApi.Models.CancelOrder.Model
{
    public class CancelOrderModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int OrderId { get; set; }
        public FundInfo FundInfo { get; set; }
    }
}
