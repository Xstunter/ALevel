using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4._1_Network.Models.Response
{
    public class BaseResponse<T>
    where T : class
    {
        public T Data { get; set; }
        public ReqresSupportResponse Support { get; set; }
    }
}
