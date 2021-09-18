using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppleMonitor.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace AppleMonitor
{
    internal class Program
    {
        private const string fsMSgUrl = "https://open.feishu.cn/open-apis/bot/v2/hook/******";

        public static readonly WebProxy GetTunnelProxy = new WebProxy()
        {
            Address = new Uri("http://http-pro.abuyun.com:9010"),
            Credentials = new NetworkCredential("******", "******")
        };

        static void Main(string[] args)
        {
            var monitorList = new List<string>()
            {
                "iPhone 13 Pro 256GB 石墨色",
                "iPhone 13 Pro 512GB 石墨色",
                "iPhone 13 Pro 256GB 远峰蓝色",
                "iPhone 13 Pro 512GB 远峰蓝色",

                "iPhone 13 Pro Max 256GB 石墨色",
                "iPhone 13 Pro Max 512GB 石墨色",
                "iPhone 13 Pro Max 256GB 远峰蓝色",
                "iPhone 13 Pro Max 512GB 远峰蓝色"

            };

            var url = "https://www.apple.com.cn/shop/pickup-message-recommendations?mt=compact&location=福建 福州 晋安区&product=MLT93CH/A";
            while (true)
            {
                try
                {
                    var client = new RestClient(url);
                    client.UseNewtonsoftJson();
                    client.Proxy = GetTunnelProxy;
                    var request = new RestRequest(Method.GET);
                    var response = client.Execute<QueryInfoModel>(request);

                    var storeInfo = response.Data.Body.PickupMessage.Stores.FirstOrDefault(x => x.StoreName == "泰禾广场");

                    if (storeInfo==null) continue;
             
                    var productList =
                        storeInfo.PartsAvailability.Where(x => monitorList.Contains(x.Value.StorePickupProductTitle))
                            .Select(x=>x.Value).ToList();


                    if (productList.Any())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("---------------------");
                        sb.AppendLine($"{DateTime.Now}");
                        foreach (var product in productList)
                        {
                            sb.AppendLine($"{product.StorePickupProductTitle}");
                            sb.AppendLine($"{product.PickupSearchQuote}");
                        }
                        sb.AppendLine("---------------------");
                        Console.WriteLine(sb.ToString());
                        Send(sb.ToString());
                    }
                    else
                    {
                        Console.WriteLine($"{DateTime.Now}\t暂时没货");
                    }
                    
                    Thread.Sleep(1000*10);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Thread.Sleep(1000);
                }
            }


        }


        public static void Send(string msg)
        {
            try
            {
                var msgData = new
                {
                    msg_type = "text",
                    content = new
                    {
                        text = msg
                    }
                };


                Debug.WriteLine($"{DateTime.Now}\t{JsonConvert.SerializeObject(msgData)}");

                var client = new RestClient(fsMSgUrl);
                var request = new RestRequest(Method.POST);
                request.AddJsonBody(msgData);
                var response = client.Execute(request);
                Console.WriteLine($"飞书消息:{response.Content}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
