using System.Collections.Generic;

namespace BtceApi.Models.ActiveOrders.Model
{
    public class ActiveOrdersModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public ICollection<Order> ActiveOrders { get; set; }
    }

    public class Order
    {
        public string OrderNumber { get; set; }
        public string Pair { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; }
        public string TimeStampCreated { get; set; }
        public int Status { get; set; }
    }
}
