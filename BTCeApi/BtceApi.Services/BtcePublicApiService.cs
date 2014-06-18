using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BtceApi.Models;
using BtceApi.Models.PublicApiModels;

namespace BtceApi.Services
{
    public sealed class BtcePublicApiService : IBtcePublicApiService
    {
        private readonly BtceApiHttpClient _httpClient;

        public BtcePublicApiService(string key, string secret)
        {
            _httpClient = new BtceApiHttpClient(key,secret);
        }
        public CurrencyPair CurrencyPair { get; set; }

        public FeeModel Fee()
        {
            var response = _httpClient.SendPostRequestToPublicApi<FeeModel>(this.CurrencyPair, "/fee");
            return response;
        }

        public TickerModel Ticker()
        {
            var response = _httpClient.SendPostRequestToPublicApi<TickerModel>(this.CurrencyPair, "/ticker");
            return response;
        }

        public IEnumerable<TradeModel> Trades()
        {
            var response = _httpClient.SendPostRequestToPublicApi<IEnumerable<TradeModel>>(this.CurrencyPair, "/trades");
            return response;
        }

        public DepthModel Depth()
        {
            var response = _httpClient.SendPostRequestToPublicApi<DepthModel>(this.CurrencyPair, "/depth");
            return response;
        }
    }
}
