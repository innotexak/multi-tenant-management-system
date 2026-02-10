using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantPM.Domain.Common
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public BaseResponse() { }

        public BaseResponse(T data, string message = null!)
        {
            Success = true;
            Data = data;
            Message = message;
        }
    }   
}
