using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantPM.Contrast.Common
{
    public class ContrastBaseResponse<T>: IContrastBaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public ContrastBaseResponse() { }

        public ContrastBaseResponse(T data, string message = null!)
        {
            Success = true;
            Data = data;
            Message = message;
        }
    }
}
