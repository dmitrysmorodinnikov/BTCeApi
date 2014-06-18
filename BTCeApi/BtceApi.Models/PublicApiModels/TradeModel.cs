using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtceApi.Models.PublicApiModels
{
    public class TradeModel
    {
        public long Date { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public long Tid { get; set; }
        public string Price_Currency { get; set; }
        public string Item { get; set; }
        public string Trade_Type { get; set; } 
    }
}
