﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ray.Serilog.Sinks.Batched;

namespace Ray.Serilog.Sinks.ServerChanBatched
{
    public class ServerChanApiClient : IPushService
    {
        private const string Host = "http://sc.ftqq.com";

        private readonly Uri _apiUrl;
        private readonly string _title;
        private readonly HttpClient _httpClient = new HttpClient();

        public ServerChanApiClient(string scKey, string title = "Ray.BiliBiliTool任务日报")
        {
            _title = title;
            _apiUrl = new Uri($"{Host}/{scKey}.send");
        }

        public override string Name => "Server酱";

        public override HttpResponseMessage PushMessage(string message)
        {
            base.PushMessage(message);
            var dic = new Dictionary<string, string>
            {
                {"text", _title},
                {
                    "desp", message.Replace("\r\n", "\r\n\r\n")
                        .Replace(Environment.NewLine,"\r\n\r\n")
                }
            };
            var content = new FormUrlEncodedContent(dic);
            var response = _httpClient.PostAsync(_apiUrl, content).GetAwaiter().GetResult();
            return response;
        }
    }
}
