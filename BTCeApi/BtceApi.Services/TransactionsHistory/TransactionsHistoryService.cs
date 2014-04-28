using System.Collections.ObjectModel;
using System.IO;
using BtceApi.Models.TransactionsHistory.BtceResponseModel;
using BtceApi.Models.TransactionsHistory.Model;

namespace BtceApi.Services.TransactionsHistory
{
    public class TransactionsHistoryService
    {
        private readonly BtceApiHttpClient _httpClient;

        public TransactionsHistoryService(string key, string secret)
        {
            _httpClient = new BtceApiHttpClient(key,secret);
        }

        public TransactionsHistoryModel TransactionsHistory(int? from, int? count, int? fromId, int? endId, string order, string since, string end)
        {
            var response = _httpClient.SendRequest(ArgsDictionaryService.TransactionsHistoryDictionary(from,count,fromId,endId,order,since,end));
            string responseStr = string.Empty;
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    responseStr = new StreamReader(responseStream).ReadToEnd();
            }
            var btceResponseModel = GetTransactionsHistoryBtceResponseModel(responseStr);
            var transactionsHistoryModel = ConvertToTransactionsHistoryModel(btceResponseModel);
            return transactionsHistoryModel;
        }

        private TransactionsHistoryModel ConvertToTransactionsHistoryModel(TransactionsHistoryBtceResponseModel transactionsHistoryBtceResponseModel)
        {
            var transactionsHistoryModel = new TransactionsHistoryModel() {Transactions = new Collection<Transaction>()};
            foreach (var btceResponseTransaction in transactionsHistoryBtceResponseModel.Return)
            {
                transactionsHistoryModel.Transactions.Add(new Transaction()
                {
                    Amount = btceResponseTransaction.Value.Amount,
                    Currency = btceResponseTransaction.Value.Currency,
                    Desc = btceResponseTransaction.Value.Desc,
                    Number = btceResponseTransaction.Key,
                    Status = btceResponseTransaction.Value.Status,
                    TimeStamp = btceResponseTransaction.Value.Timestamp,
                    Type = btceResponseTransaction.Value.Type
                });
            }
            return transactionsHistoryModel;
        }

        private TransactionsHistoryBtceResponseModel GetTransactionsHistoryBtceResponseModel(string responseStr)
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<TransactionsHistoryBtceResponseModel>(responseStr);
        }
    }
}
