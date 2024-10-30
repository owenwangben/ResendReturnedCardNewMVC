using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ResendReturnedCard.Models
{
    public class SelectionFillOutView: IValidatableObject
    {
        public BaseResponse QueryResult { get; set; }
        [Required(ErrorMessage = "請選擇一張卡片")]
        public List<string>card {  get; set; }
        [Required(ErrorMessage ="請選擇地址")]
        public string addres { get; set; }
    }
}