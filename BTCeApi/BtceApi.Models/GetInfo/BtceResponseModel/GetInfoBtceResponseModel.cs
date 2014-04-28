namespace BtceApi.Models.GetInfo.BtceResponseModel
{
    public class GetInfoBtceResponseModel
    {
       public bool Success { get; set; }
       public Return Return { get; set; }
    }

    public class Return
    {
        public FundInfo Funds { get; set; }
        public RightInfo Rights { get; set; }
        public string Server_Time { get; set; }
        public int Open_Orders { get; set; }
        public int Transaction_Count { get; set; }
    }
}
