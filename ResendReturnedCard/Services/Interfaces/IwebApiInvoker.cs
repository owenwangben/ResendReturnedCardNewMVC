using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResendReturnedCard.Services;

namespace ResendReturnedCard.Services.Interfaces
{
    public interface IwebApiInvoker
    {
            Task<T> GetAsync<T>(string url);
            Task<T> PostAsync<T>(string url, object data);
    }
}
