using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Reservation : BaseEntity
    {
        [Required]
        public User User { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string State { get; set; }
    }
}
