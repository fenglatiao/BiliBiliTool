﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ray.Serilog.Sinks.Batched;

namespace Ray.Serilog.Sinks.DingTalkBatched
{
    public class DingTalkApiClient : IPushService
    {
        private readonly Uri _apiUrl;
        private readonly HttpClient _httpClient = new HttpClient();

        public DingTalkApiClient(string webHookUrl)
        {
            _apiUrl = new Uri(webHookUrl);
        }

        public override string Name => "钉钉";

        public override HttpResponseMessage PushMessage(string message)
        {
            base.PushMessage(message);

            var json = new
            {
                msgtype = "markdown",
                markdown = new
                {
                    title = "Ray.BiliBiliTool任务日报",
                    text = message.Replace("\r\n", "\r\n\r\n")
                        .Replace(Environment.NewLine, "\r\n\r\n")
                }
            }.ToJson();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(_apiUrl, content).GetAwaiter().GetResult();
            return response;
        }
    }
}
