namespace Shopping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Favorites
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Link { get; set; }

        public virtual User User { get; set; }

        /*购物车 新添显示数据
         作者：zmx
         时间：2020/12/22
         */

        public string imagepath { get; set; }
        public string type { get; set; }
        public string name { get; set; }

        public double price { get; set; }
        public int number { get; set; }

    }
}
