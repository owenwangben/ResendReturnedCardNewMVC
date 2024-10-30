using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResendReturnedCard.Models
{
    //RequestApplyApi
    public class ResendReturnedCardApplyRequestModel
    {
        public string ID { set; get; }
        public List<string> Cards { get; set; }
        public string AddrType { get; set; }
        public string OtherZip { get; set; }
        public string OtherAddr { get; set; }
    }
    public class HeaderModel
    {
        public string ApplicationName { get; set; }
    }
    public class RequestApplyModel
    {
        public ResendReturnedCardApplyRequestModel ResendReturnedCardApplyRequest { get; set; }
        public HeaderModel Header { get; set; }
    }

    //ResponseApplyApi
    public class ResultApplyModel
    {
        public List<string> FailCards { set; get; }
    }
    public class ResponseApplyModel
    {
        public ResultApplyModel ResultApply { get; set; }
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}