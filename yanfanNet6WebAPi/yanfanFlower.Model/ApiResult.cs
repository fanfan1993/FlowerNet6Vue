using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanfanFlower.Model
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }

        public object Result { get; set; }

        public string Msg { get; set; }
    }
}
