using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;

namespace ResendReturnedCard.Models
{
    public class RequestModel
    {
        public ContentModel Content { get; set; }
    }

    public class ContentModel
    {
        public string ID { get; set; }
    }

    public class BaseResponse
    {
        public QueryReturnedCardInfo Result { get; set; }
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }

    public class QueryReturnedCardInfo
    {
        public List<sp_CampaignCallList_Resend_Request_Item> Items { get; set; }
    }

    public class sp_CampaignCallList_Resend_Request_Item
    {
        public string ID { get; set; }

        public string CardNo { get; set; }
        public string CardName { get; set; }

        public string HomeAddr { get; set; }

        public string CompanyAddr { get; set; }

        public string RegisterAddr { get; set; }

        public string MaskedCarNo => MaskCardNo(CardNo);
        public string MaskCardNo(string cardNumber)
        {
            if(string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 16)
            {
                return cardNumber;
            }
            var maskedPart = new string('*', 8);
            return cardNumber.Substring(0,4) + maskedPart + cardNumber.Substring(12);
        }
    }

    public class Step2ViewModel
    {
        public List<sp_CampaignCallList_Resend_Request_Item> SelectedCardList { get; set; }
    }
}