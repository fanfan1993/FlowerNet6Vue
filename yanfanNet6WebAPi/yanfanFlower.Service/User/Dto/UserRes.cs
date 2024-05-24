using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanfanFlower.Service.User.Dto
{
    public class UserRes
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }

       public DateTime? CreateTime { get; set; }

    }
}
