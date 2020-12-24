namespace Shopping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        public DateTime StartTime { get; set; }

        [Required]
        public string Logistics { get; set; }

        public int? CustomerID { get; set; }

        public int? SellerID { get; set; }

        public int? CommodityID { get; set; }

        public virtual Commodity Commodity { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        //add by zmx
        public string imagepath { get; set; }

        public double? price { get; set; }

        public int? number { get; set; }

        public string username { get; set; }

        public string comname { get; set; }
    }
}
