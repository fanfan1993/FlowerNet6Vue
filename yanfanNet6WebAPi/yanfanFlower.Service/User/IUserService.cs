using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanfanFlower.Service.User.Dto;

namespace yanfanFlower.Service
{
    public interface IUserService
    {
        // 登录
        UserRes GetUsers(UserReq req);
        // 注册
        UserRes RegisterUser(RegisterReq req, ref string msg);
        //object RegisterUser(RegisterReq req, ref string msg);
    }
}
