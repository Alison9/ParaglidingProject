using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParaglidingProject.SL.Core.Subscription.NS.transferObjects
{
    public class SubscriptionDto
    {
        [Display(Name = "Date")]
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int NumberOfPayments { get; set; }

        public bool IsActive { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
