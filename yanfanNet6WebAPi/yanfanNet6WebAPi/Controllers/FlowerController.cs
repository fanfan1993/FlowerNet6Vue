using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yanfanFlower.Model;
using yanfanFlower.Model.Entitys;
using yanfanFlower.Service.Flower;

namespace yanfanNet6WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        public IFlowerService _flowerService;

        public FlowerController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }

        [HttpPost]
        //List<FlowerRes>
        public ApiResult GetFlowers(FlowerReq req)
        {

            ApiResult apiResult = new ApiResult() { IsSuccess = true };
            apiResult.Result = _flowerService.GetFlowers(req);
            return apiResult;
            //return new List<Flower>() {
            //    ///new Flower(){ ImageUrl= "/images/banners/21_birthday_banner_pc.jpg",CourseUrl="http://localhost:5173/" },

            //// "/images/banners/21_birthday_banner_pc.jpg","/images/banners/21_brand_banner_pc.jpg","/images/banners/21_syz_banner_pc.jpg"
            //};
        }
    }
}
