using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ParaglidingProject.Entities.Models;

namespace ParaglidingProject.Models
{
    public class Subscription: IMyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Année")]
        public int Year { get; set; }
        [Display(Name = "Prix")]
        [DisplayFormat(DataFormatString = "{0:C}")]

        public decimal SubscriptionAmount { get; set; }

        public ICollection<SubscriptionPayment> SubscriptionPayments { get; set; }

        public bool IsActive { get; set; }
    }
}
