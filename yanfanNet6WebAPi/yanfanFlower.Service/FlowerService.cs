using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yanfanFlower.Common;
using yanfanFlower.Service.Flower;
using yanfanFlower.Model.Entitys;
using Mapster;

namespace yanfanFlower.Service
{
    public class FlowerService : IFlowerService
    {

        //private readonly IMapper _mapper;
        //public FlowerService(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}
        public List<FlowerRes> GetFlowers(FlowerReq req)
        {
            var flower = DbContext.db.Queryable<Flowers>().WhereIF(req.Id > 0, p => p.Id == req.Id).WhereIF(req.Type > 0, p => p.Type == req.Type).ToList();
            return flower.Adapt<List<FlowerRes>>();
            //return _mapper.Map<List<FlowerRes>>(flower);
        }
    }
}
