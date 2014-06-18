using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace BtceApi.Services
{
    public class BtceApiHttpClient
    {
        private const string ServerUrl = "https://btc-e.com/tapi";
        private const string PublicApiUrl = "https://btc-e.com/api/2/";
        private readonly string _key ;
        readonly HMACSHA512 _hashMaker;

        public BtceApiHttpClient()
        {
            
        }

        public BtceApiHttpClient(string key, string secret)
        {
            _key = key;
            _hashMaker = new HMACSHA512(Encoding.UTF8.GetBytes(secret));
        }

        public TResult SendPostRequestToTradeApi<TResult>(Dictionary<string, string> argsDictionary)
        {
            var request = (HttpWebRequest)WebRequest.Create(ServerUrl);
            var postDataStr = BuildPostData(argsDictionary);
            var postData = Encoding.UTF8.GetBytes(postDataStr);

            request.Method = "POST";
            request.Timeout = 15000;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Headers.Add("Key", _key);
            request.Headers.Add("Sign", GetDataSignature(postData));

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(postData, 0, postData.Length);
            }
            string responseStr = string.Empty;
            using (var responseStream = request.GetResponse().GetResponseStream())
            {
                if (responseStream != null)
                    responseStr = new StreamReader(responseStream).ReadToEnd();
            }
            return JsonConvert.DeserializeObject<TResult>(responseStr);
        }

        public TResult SendPostRequestToPublicApi<TResult>(CurrencyPair currencyPair, string method)
        {
            string requestUrl = PublicApiUrl + EnumHelper.GetEnumDescription(currencyPair) + method;
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            var postData = Encoding.UTF8.GetBytes(string.Empty);

            request.Method = "POST";
            request.Timeout = 15000;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Headers.Add("Key", _key);
            request.Headers.Add("Sign", GetDataSignature(postData));

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(postData, 0, postData.Length);
            }
            string responseStr = string.Empty;
            using (var responseStream = request.GetResponse().GetResponseStream())
            {
                if (responseStream != null)
                    responseStr = new StreamReader(responseStream).ReadToEnd();
            }
            return JsonConvert.DeserializeObject<TResult>(responseStr);
        }

        private static string BuildPostData(Dictionary<string, string> argsDictionary)
        {
            var sb = new StringBuilder();
            foreach (var item in argsDictionary)
            {
                sb.AppendFormat("{0}={1}", item.Key, HttpUtility.UrlEncode(item.Value));
                sb.Append("&");
            }
            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
            return sb.ToString(); 
        }

        private string GetDataSignature(byte[] postData)
        {
            var hash = _hashMaker.ComputeHash(postData);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
