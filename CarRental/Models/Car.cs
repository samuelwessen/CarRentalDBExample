using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public partial class Car
    {
        public Car()
        {
            CarOrder = new HashSet<CarOrder>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        [StringLength(4)]
        public string YearModel { get; set; }
        [Required]
        [StringLength(6)]
        public string RegNr { get; set; }

        [InverseProperty("Car")]
        public virtual ICollection<CarOrder> CarOrder { get; set; }
    }
}
