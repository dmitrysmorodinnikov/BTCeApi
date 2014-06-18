using System.Collections.Generic;

namespace BtceApi.Models.TradeApiModels.TransactionsHistory.Model
{
    public class TransactionsHistoryModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public ICollection<Transaction> Transactions { get; set; } 
    }

    public class Transaction
    {
        public string Number { get; set; }
        public int Type { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Desc { get; set; }
        public int Status { get; set; }
        public string TimeStamp { get; set; }
    }
}
