namespace Shopping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bankcard")]
    public partial class Bankcard
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        [StringLength(30)]
        public string IdCard { get; set; }

        [Required]
        [StringLength(30)]
        public string BankAcount { get; set; }

        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(30)]
        public string BankPassword { get; set; }

        [StringLength(30)]
        public string BankName { get; set; }

        [StringLength(30)]
        public string BankShortName { get; set; }

        public string logo { get; set; }

        [StringLength(30)]
        public string BankTel { get; set; }

        public double Money { get; set; }

        public string BankWebSite { get; set; }

        [StringLength(10)]
        public string BankCode { get; set; }

        [StringLength(30)]
        public string PhoneNumber { get; set; }

        public virtual User User { get; set; }
    }
}
