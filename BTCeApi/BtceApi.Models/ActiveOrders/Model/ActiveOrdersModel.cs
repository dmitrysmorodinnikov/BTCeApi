using System.Collections.Generic;

namespace BtceApi.Models.ActiveOrders.Model
{
    public class ActiveOrdersModel
    {
        public ICollection<Order> ActiveOrders { get; set; } 
    }
    
}
