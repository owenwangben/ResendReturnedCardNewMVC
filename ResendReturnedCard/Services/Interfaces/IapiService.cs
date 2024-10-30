using ResendReturnedCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResendReturnedCard.Services.Interfaces
{
    public interface IapiService
    {
        Task<BaseResponse> GetData(string id);
    }
}
