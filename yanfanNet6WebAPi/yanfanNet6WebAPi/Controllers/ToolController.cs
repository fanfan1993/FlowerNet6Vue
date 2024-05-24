using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yanfanFlower.Common;

namespace yanfanNet6WebAPi.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToolController : ControllerBase
    {
      
        [HttpGet]
        public string InitDatabase()
        {
            string res = String.Empty;
            try
            {
                DbContext.InitDatabase();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }

    }
}
