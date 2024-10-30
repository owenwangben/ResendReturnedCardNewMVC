using Newtonsoft.Json;
using ResendReturnedCard.Models;
using ResendReturnedCard.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace ResendReturnedCard.Controllers
{
    public class ResendReturnedCardController : Controller
    {
        private readonly ApiService _apiService;

        public ResendReturnedCardController(ApiService apiService)
        {
            _apiService = apiService;
        }

        //GET:step1
        [HttpGet]
        public async Task<ActionResult> Step1()
        {
            var response = await _apiService.GetData("A900000794");
            var model = new SelectionFillOutView
            {
                QueryResult = response ?? new BaseResponse { Result = new QueryReturnedCardInfo { Items = new List<sp_CampaignCallList_Resend_Request_Item>() } },
                card = new List<string>(),
                addres = string.Empty
            };
            return View(model);
        }
        //POST
       


        //GET:step2
        public ActionResult Step2()
        {
           return View();
        }
       
        [HttpPost]
        public async Task<ActionResult> Step2(ResendReturnedCardApplyRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var RequestApplyModel = new RequestApplyModel
            {
                ResendReturnedCardApplyRequest = new ResendReturnedCardApplyRequestModel {
                    ID = "A900000794",
                    Cards = model.Cards,
                    AddrType = model.AddrType,
                    OtherZip = model.OtherZip,
                    OtherAddr = model.OtherAddr
                },
                Header = new HeaderModel
                {
                    ApplicationName = "EWEB2"
                }
            };
            //ResponseApplyModel responseApplyModel = await PostAsync<ResponseApplyModel>("http://localhost:3000/api/Apply/ResendReturnedCard", RequestApplyModel);
            //if(responseApplyModel.ResultCode == "00")
            //{
              //  return RedirectToAction("Step3");
                
            //}
            //else
            //{
              //  TempData["failMsg"] = "申請失敗";
                //return RedirectToAction("Step3");
            //}
            return View(RequestApplyModel);
         }
    
        //GET:step3
            public ActionResult Step3()
        {
            var stepData = TempData["stepData"] as List<sp_CampaignCallList_Resend_Request_Item>;
            ViewBag.addres = TempData["addres"];
            if (stepData == null || !stepData.Any())
            {
                return RedirectToAction("step2");
            }
            if (TempData["failMsg"] != null)
            {
                ViewBag.failMsg = TempData["failMsg"];
            }
            return View(stepData);
        }
    }
}
       
    
