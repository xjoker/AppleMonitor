using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using AppleMonitor.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace AppleMonitor
{
    internal class Program
    {
        /// <summary>
        ///     飞书通知URL
        /// </summary>
        private const string FsMSgUrl = "https://open.feishu.cn/open-apis/bot/v2/hook/******";

        /// <summary>
        ///     使用代理避免风控
        /// </summary>
        public static readonly WebProxy GetTunnelProxy = new WebProxy
        {
            Address = new Uri("http://127.0.0.1:7890")
            //Credentials = new NetworkCredential("******", "******")
        };

        private static void Main()
        {
            var interval = 10; //间隔时间
            var locationName = "福建 福州 晋安区"; //所在区域，需要苹果页面格式
            var productName = "MPXR3CH/A"; //监视机型型号
            var storeName = "泰禾广场"; //商铺名称
            var storageSize = new List<string> { "128GB", "256GB", "512GB", "1TB" }; //监视容量
            var colorType = new List<string> { "午夜色", "银色", "深空黑色", "暗紫色", "绿色" }; //监视颜色
            var phoneType = new List<string>
            {
                "iPhone 14 Pro", "iPhone 14 Pro Max", "iPhone 14 Plus", "iPhone 14", "iPhone 13"
            }; //监视机型,特别注意空格不是 HEX 20 而是 A0

            // 缺货推荐机型
            var recommendationsUrl =
                $"https://www.apple.com.cn/shop/pickup-message-recommendations?mt=compact&location={locationName}&product={productName}";

            // 店内库存
            var fulfillmentUrl =
                $"https://www.apple.com.cn/shop/fulfillment-messages?pl=true&mts.0=regular&parts.0={productName}&location={locationName}";

            while (true)
                try
                {
                    CheckRecommendations(recommendationsUrl, storeName, storageSize, colorType, phoneType);
                    CheckFulfillment(fulfillmentUrl, storeName, storageSize, colorType, phoneType);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    Thread.Sleep(1000 * interval);
                }

            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        ///     无库存推荐机型
        /// </summary>
        /// <param name="url"></param>
        /// <param name="storeName"></param>
        /// <param name="storageSize"></param>
        /// <param name="colorType"></param>
        /// <param name="phoneType"></param>
        private static void CheckRecommendations(string url, string storeName, List<string> storageSize,
            List<string> colorType, List<string> phoneType)
        {
            var client = new RestClient(url);
            client.UseNewtonsoftJson();
            client.Proxy = GetTunnelProxy;
            var request = new RestRequest(Method.GET);
            var response = client.Execute<QueryInfoModel>(request);

            if (response.Data.Body.PickupMessage.Stores == null)
            {
                Console.WriteLine($"{DateTime.Now}\t{response.Data.Body.NoSimilarModelsText}");
                return;
            }

            var storeInfo =
                response.Data.Body.PickupMessage.Stores.FirstOrDefault(x => x.StoreName == storeName);

            if (storeInfo == null) return;

            var storePhoneList = storeInfo.PartsAvailability
                .Select(x => x.Value.StorePickupProductTitle)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();


            var availablePhone = storePhoneList.Distinct()
                .Where(phoneTypeStr => storageSize.Any(phoneTypeStr.Contains) && //容量过滤
                                       colorType.Any(phoneTypeStr.Contains) && // 颜色过滤
                                       phoneType.Any(phoneTypeStr.Contains)) //机型过滤
                .ToList();

            var productList =
                storeInfo.PartsAvailability.Where(x => availablePhone.Contains(x.Value.StorePickupProductTitle))
                    .Select(x => x.Value).ToList();

            if (productList.Any())
            {
                var sb = new StringBuilder();
                sb.AppendLine("---------------------");
                sb.AppendLine($"{DateTime.Now}");
                foreach (var product in productList)
                {
                    sb.AppendLine("无库存推荐机型");
                    sb.AppendLine($"{product.StorePickupProductTitle}");
                    sb.AppendLine($"{product.PickupSearchQuote}");
                }

                sb.AppendLine("---------------------");
                Console.WriteLine(sb.ToString());
                // 发送消息
                Send(sb.ToString());
            }
            else
            {
                Console.WriteLine($"{DateTime.Now}\t暂时没货");
            }
        }

        /// <summary>
        ///     现有库存机型
        /// </summary>
        /// <param name="url"></param>
        /// <param name="storeName"></param>
        /// <param name="storageSize"></param>
        /// <param name="colorType"></param>
        /// <param name="phoneType"></param>
        private static void CheckFulfillment(string url, string storeName, List<string> storageSize,
            List<string> colorType, List<string> phoneType)
        {
            var client = new RestClient(url);
            client.UseNewtonsoftJson();
            client.Proxy = GetTunnelProxy;
            var request = new RestRequest(Method.GET);
            var response = client.Execute<QueryInfoModel>(request);

            var storeInfo =
                response.Data.Body.Content.PickupMessage.Stores.FirstOrDefault(x => x.StoreName == storeName);

            if (storeInfo == null) return;

            var storeRegularPhoneList = storeInfo.PartsAvailability
                .Select(x => x.Value.MessageTypes.Regular.StorePickupProductTitle)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();

            var availablePhone = storeRegularPhoneList.Distinct()
                .Where(phoneTypeStr => storageSize.Any(phoneTypeStr.Contains) && //容量过滤
                                       colorType.Any(phoneTypeStr.Contains) && // 颜色过滤
                                       phoneType.Any(phoneTypeStr.Contains)) //机型过滤
                .ToList();

            var productList =
                storeInfo.PartsAvailability.Where(x =>
                        availablePhone.Contains(x.Value.MessageTypes.Regular.StorePickupProductTitle))
                    .Select(x => x.Value).ToList();

            if (productList.Any())
            {
                var sb = new StringBuilder();
                sb.AppendLine("---------------------");
                sb.AppendLine($"{DateTime.Now}");
                foreach (var product in productList)
                {
                    sb.AppendLine("现有库存机型");
                    sb.AppendLine($"{product.MessageTypes.Regular.StorePickupProductTitle}");
                    sb.AppendLine($"{product.PickupSearchQuote}");
                }

                sb.AppendLine("---------------------");
                Console.WriteLine(sb.ToString());
                // 发送消息
                Send(sb.ToString());
            }
            else
            {
                Console.WriteLine($"{DateTime.Now}\t暂时没货");
            }
        }

        /// <summary>
        ///     发送消息
        /// </summary>
        /// <param name="msg"></param>
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

                var client = new RestClient(FsMSgUrl);
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