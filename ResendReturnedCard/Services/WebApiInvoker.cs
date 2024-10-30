using Newtonsoft.Json;
using ResendReturnedCard.Models;
using ResendReturnedCard.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ResendReturnedCard.Services
{
    public class WebApiInvoker : IwebApiInvoker
    {
        private readonly HttpClient _httpClient;

        public WebApiInvoker(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // POST 方法
        public async Task<T> PostAsync<T>(string url, object data)
        {
            //將data物件序列化為JSON字串
            var json = JsonConvert.SerializeObject(data);
            //將JSON字串包裝成StringContent，並設定內容類型為"application/json"，使用UTF-8編碼(全球通用編碼格式)
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //客戶端發送請求至指定URL，content為請求主體，非同步操作，程式等待回應
            var response = await _httpClient.PostAsync(url, content);
            //程式回應狀態碼，成功為2XX
            response.EnsureSuccessStatusCode();

            //將回應的內容讀取為字串
            var responseJson = await response.Content.ReadAsStringAsync();
            //回應的JSON反序列化為型別T的物件
            return JsonConvert.DeserializeObject<T>(responseJson);
        }

        // GET 方法
        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}