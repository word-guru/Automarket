using Automarket.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode Status { get; set; }
        public T Data { get; set; }
    }
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
    }
}
