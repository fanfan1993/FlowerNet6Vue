using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using yanfanFlower.Common;
using yanfanFlower.Model;
using yanfanFlower.Model.Entitys;
using yanfanFlower.Service;
using yanfanFlower.Service.User.Dto;

namespace yanfanNet6WebAPi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 验证码获取
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetValidateCodeImage(string t)
        {
            var validateCodeString = Tools.CreateValidateString();
            // 将验证码存在缓存中
            MemoryHelper.SetMemory(t, validateCodeString, 5);
            // 将图片返回的二进制
            byte[] buffer = Tools.CreateValidateCodeBuffer(validateCodeString);

            var s = System.IO.File.Create(Path.Combine(AppContext.BaseDirectory, "x.jpg"));
            s.Write(buffer, 0, buffer.Length);
            s.Close();

            return File(buffer, @"image/jpeg");
        }

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Check(UserReq req)
        {

            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password)
                || string.IsNullOrEmpty(req.ValidateCode) || string.IsNullOrEmpty(req.ValidateKey))
            {
                apiResult.Msg = "参数不能为空!";
            }
            else if (currCode == null)
            {
                apiResult.Msg = "验证码不存在，请刷新验证码!";
            }
            else if (currCode.ToString() !=req.ValidateCode)
            {
                apiResult.Msg = "验证码错误，请重新输入验证码!";
            }
            else
            {

                UserRes user = _userService.GetUsers(req);
                if (string.IsNullOrEmpty(user.UserName))
                {
                    apiResult.Msg = "账号不存在，用户名错误或密码错误";
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = user.NickName;

                }
            }
            return apiResult;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Register(RegisterReq req)
        {

            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.NickName) || string.IsNullOrEmpty(req.Password)
                || string.IsNullOrEmpty(req.ValidateCode) || string.IsNullOrEmpty(req.ValidateKey))
            {
                apiResult.Msg = "参数不能为空!";
            }
            else if (currCode == null)
            {
                apiResult.Msg = "验证码不存在，请刷新验证码!";
            }
            else if (currCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "验证码错误，请重新输入验证码!";
            }
            else
            {
                string msg = string.Empty;
                var res = _userService.RegisterUser(req, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = req.NickName;

                }
            }
            return apiResult;
        }
    }
}
