using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BtceApi.Models;
using BtceApi.Models.PublicApiModels;

namespace BtceApi.Services
{
    public interface IBtcePublicApiService
    {
        CurrencyPair CurrencyPair { get; set; }
        FeeModel Fee();
        TickerModel Ticker();
        IEnumerable<TradeModel> Trades();
        DepthModel Depth();

    }
}
