using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string PersonNr { get; set; }
        [Required]
        [StringLength(50)]
        public string Adress { get; set; }
        [Required]
        [StringLength(5)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNr { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
