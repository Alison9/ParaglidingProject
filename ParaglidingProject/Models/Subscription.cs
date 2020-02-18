using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParaglidingProject.Models
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YearID { get; set; }
        public decimal Price { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
