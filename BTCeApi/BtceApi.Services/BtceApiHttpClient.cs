using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BtceApi.Services
{
    public class BtceApiHttpClient
    {
        private const string ServerUrl = "https://btc-e.com/tapi";
        private readonly string _key ;
        readonly HMACSHA512 _hashMaker;

        public BtceApiHttpClient(string key, string secret)
        {
            _key = key;
            _hashMaker = new HMACSHA512(Encoding.UTF8.GetBytes(secret));
        }

        public TResult SendRequest<TResult>(Dictionary<string, string> argsDictionary)
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
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<TResult>(responseStr);
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
