using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtceApi.Services
{
    public enum CurrencyPair
    {
        [Description("btc_usd")]
        BtcUsd,
        [Description("btc_eur")]
        BtcEur,
        [Description("btc_rur")]
        BtcRur,
        [Description("ltc_btc")]
        LtcBtc,
        [Description("ltc_usd")]
        LtcUsd,
        [Description("ltc_rur")]
        LtcRur,
        [Description("nmc_btc")]
        NmcBtc,
        [Description("usd_rur")]
        UsdRur,
        [Description("eur_usd")]
        EurUsd
    }
}
