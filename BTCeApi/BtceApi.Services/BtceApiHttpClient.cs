using System;
using System.Collections.Generic;
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
        public WebResponse SendRequest(Dictionary<string,string>argsDictionary)
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

            return request.GetResponse();
        }

        private string BuildPostData(Dictionary<string, string> argsDictionary)
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in argsDictionary)
            {
                s.AppendFormat("{0}={1}", item.Key, HttpUtility.UrlEncode(item.Value));
                s.Append("&");
            }
            if (s.Length > 0) s.Remove(s.Length - 1, 1);
            return s.ToString(); 
        }

        private string GetDataSignature(byte[] postData)
        {
            var hash = _hashMaker.ComputeHash(postData);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
