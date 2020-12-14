namespace Shopping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shop")]
    public partial class Shop
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public int SellerId { get; set; }

        public double Score { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime CreatTime { get; set; }

        [Required]
        [StringLength(50)]
        public string LicenseId { get; set; }

        public long FansNumber { get; set; }

        public virtual User User { get; set; }
    }
}
