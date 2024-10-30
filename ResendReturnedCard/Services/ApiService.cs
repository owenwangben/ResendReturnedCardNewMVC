using ResendReturnedCard.Models;
using ResendReturnedCard.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ResendReturnedCard.Services
{
    public class ApiService : IapiService
    {
        private readonly IwebApiInvoker _webApiInvoker;

        public ApiService(IwebApiInvoker webApiInvoker)
        {
            _webApiInvoker = webApiInvoker;
        }

        public async Task<BaseResponse> GetData(string id)
        {
            var requestModel = new RequestModel
            {
                Content = new ContentModel
                {
                    ID = id
                }
            };
            string url = "http://localhost:3000/api/Apply/QueryReturnedCardInfo";
            // 調用API獲取資料，回應資料型別 : 包含QueryReturnedCardInfo型別資料。("API的URL" , "發送給API的請求資料")
            return await _webApiInvoker.PostAsync<BaseResponse>(url, requestModel);
        }
    }
}