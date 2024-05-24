using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using yanfanNet6WebAPi;

namespace ZhaoxiFlower.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        public List<ImageModel> GetImages()
        {
            return new List<ImageModel>() {
                new ImageModel(){ ImageUrl= "/images/banners/21_birthday_banner_pc.jpg",CourseUrl="http://localhost:5173/" },
                new ImageModel(){ ImageUrl= "/images/banners/21_brand_banner_pc.jpg",CourseUrl="http://localhost:5173/" },
                new ImageModel(){ ImageUrl= "/images/banners/21_brand_banner_pc.jpg",CourseUrl="http://localhost:5173/" },
            // "/images/banners/21_birthday_banner_pc.jpg","/images/banners/21_brand_banner_pc.jpg","/images/banners/21_syz_banner_pc.jpg"
            };
        }
    }
}
