using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtceApi.Models.PublicApiModels
{
    public class DepthModel
    {
        public IEnumerable<IEnumerable<string>> Asks { get; set; }
        public IEnumerable<IEnumerable<string>> Bids { get; set; } 
    }
}
