using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanfanFlower.Model.Entitys;
using yanfanFlower.Service.Flower;

namespace yanfanFlower.Service.Config
{
    public class AutoMapperConfigs: Profile
    {
        /// <summary>
        /// 管理构造映射
        /// </summary>
        public AutoMapperConfigs() {
            //管理映射关系 A -B 
            CreateMap<Flowers, FlowerRes>();
        }
    }
}
