using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanfanFlower.Model.Entitys
{
    public class Flowers
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        [SugarColumn(IsNullable = false)]
        public string Title { get; set; }
        [SugarColumn(IsNullable = false)]
        public int Type { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Image { get; set; }
        [SugarColumn(IsNullable = false)]
        public string BigImage { get; set; }
        [SugarColumn(IsNullable = false)]
        public string Description { get; set; }
        [SugarColumn(IsNullable = false)]
        public decimal Price { get; set; }
        [SugarColumn(IsNullable = false)]
        public string Language { get; set; }
        [SugarColumn(IsNullable = false)]
        public string Material { get; set; }
        [SugarColumn(IsNullable = false)]
        public string Packing { get; set; }
        [SugarColumn(IsNullable = false)]
        public string DeliveryRemarks { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Desc { get; set; }
       

    }
}
