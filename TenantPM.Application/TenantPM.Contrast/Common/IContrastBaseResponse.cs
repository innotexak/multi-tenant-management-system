using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantPM.Contrast.Common
{
    public interface IContrastBaseResponse
    {
            bool Success { get; }
            string Message { get; }
            List<string>? Errors { get; }
     }

        public interface IContrastBaseResponse<out T> : IContrastBaseResponse
    {
            T? Data { get; }
        }
  
}
