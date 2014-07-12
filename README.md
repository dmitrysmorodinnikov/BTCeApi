BTCeApi
=======
It is btc-e.com API .NET Library

This full-featured btc-e.com API wrapper written in C# provides a quick access to all available BTC-E features.

Because of good design and clean natural object oriented approach, the library is easy to use. 

I guess it can save some time for developers who are implementing their own trading strategies. You can easily build
your strategy with this library as the base.

You can look for code examples in SamplesProject which is a part of the solution.

Installation
==============
To install BtceAPI with Nuget, run the following command in the Package Manager Console
```
PM> Install-Package BtceAPI
```

Code examples
==============
To create an instance of BTCeApi:
```
var apiSecret = "Your_Secret";
var apiKey = "Your_Key";
var btce = new Btce(apiKey,apiSecret);
```

After creating an instance different API methods are available:
```
var info = btce.GetInfo();

var activeOrders = btce.ActiveOrders(Pair.btc_usd);

var transactionsHistory = btce.TransactionsHistory();

var tradeHistory = btce.TradeHistory();

var trade = btce.Trade(Pair.btc_usd, OperationType.buy, 10.1, 1.1);

var cancelOrder = btce.CancelOrder(222052617);

var btcUsdFee = btce.BtcUsd.Fee();
```
========================
If you find the library useful and would like to donate (and many thanks to those that have donated!), please send some
 coins here:


```
LTC LfuExh8hoJVpqvfbxtA6hmtrkz8fzmLvhb

BTC 1C1eyDwrPrfzRHir54euX1kmiGAMz29c7x

```

Author
========
<a href="https://twitter.com/federer_15" target=_blank title="My Twitter">@federer_15</a><br/>
<a href="http://smorodinnikov.com" target=_blank title="Dmitry Smorodinnikov">My Blog</a>