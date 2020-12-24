namespace Shopping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Bankcard = new HashSet<Bankcard>();
            DeliveryAddress = new HashSet<DeliveryAddress>();
            Favorites = new HashSet<Favorites>();
            Order = new HashSet<Order>();
            Order1 = new HashSet<Order>();
            Shop = new HashSet<Shop>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="����")]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string IdCard { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "�绰����")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "����")]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "�Ա�")]
        public string Sex { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "����")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "����")]
        public string MailBox { get; set; }

        [Required]
        [Display(Name = "���")]
        public string Sign { get; set; }

        [Required]
        [StringLength(10)]
        public string TType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bankcard> Bankcard { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryAddress> DeliveryAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorites> Favorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop> Shop { get; set; }
    }
}
