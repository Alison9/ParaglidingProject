﻿using System;
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
        public int YearID { get; set; }
        [Display(Name = "Prix")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
