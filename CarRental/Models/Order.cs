using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public partial class Order
    {
        public Order()
        {
            CarOrder = new HashSet<CarOrder>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Order")]
        public virtual Customer Customer { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<CarOrder> CarOrder { get; set; }
    }
}
