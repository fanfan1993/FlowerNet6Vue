using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanfanFlower.Common;
using yanfanFlower.Model.Entitys;
using Mapster;
using yanfanFlower.Service.User.Dto;
using yanfanFlower.Model.Enum;

namespace yanfanFlower.Service
{
    public class UserService : IUserService
    {

        //private readonly IMapper _mapper;
        //public FlowerService(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}


        public UserRes GetUsers(UserReq req)
        {
            var user = DbContext.db.Queryable<Users>().First(p => p.UserName == req.UserName && p.Password == req.Password);
            if (user != null)
            {
                return user.Adapt<UserRes>();
            }
            return new UserRes();
        }

        public UserRes RegisterUser(RegisterReq req, ref string msg)
        {
            var user = DbContext.db.Queryable<Users>().First(p => p.UserName == req.UserName);
            if (user != null)
            {
                msg = "账号已存在";
                return user.Adapt<UserRes>();
            }
            else
            {
                try
                {
                    Users users = new Users();
                    users.Password = req.Password;
                    users.NickName = req.NickName;
                    users.UserName = req.UserName;
                    users.CreateTime = DateTime.Now;
                    users.UserType = (int)EnumUserType.普通用户;
                    bool res = DbContext.db.Insertable(users).ExecuteCommand() > 0;
                    if (res)
                    {
                        user = DbContext.db.Queryable<Users>().First(p => p.UserName == req.UserName && p.Password == req.Password);
                        //&& p.Password == req.Password
                        return user.Adapt<UserRes>();
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
            return new UserRes();
        }

    }
}
