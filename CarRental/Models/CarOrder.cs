using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public partial class CarOrder
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int CarId { get; set; }
        public int RentalDays { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty("CarOrder")]
        public virtual Car Car { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("CarOrder")]
        public virtual Order Order { get; set; }
    }
}
