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

        /*���ﳵ ������ʾ����
         ���ߣ�zmx
         ʱ�䣺2020/12/22
         */

        public string imagepath { get; set; }
        public string type { get; set; }
        public string name { get; set; }

        public double price { get; set; }
        public int number { get; set; }

    }
}
