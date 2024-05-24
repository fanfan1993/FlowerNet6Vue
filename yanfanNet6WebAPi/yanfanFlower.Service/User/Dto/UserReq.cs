using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanfanFlower.Service.User.Dto
{
    public class UserReq
    {
        public string UserName { get; set; }
       // public string NickName { get; set; }

        public string Password { get; set; }

        public string ValidateCode { get; set; }
        public string ValidateKey { get; set; }
    }
}
