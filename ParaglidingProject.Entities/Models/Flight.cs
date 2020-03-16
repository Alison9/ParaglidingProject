﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Flight
    {
        public int ID { get; set; }
        [Display(Name="Date du vol")]
        [DataType(DataType.Date)]
        public DateTime FlightDate { get; set; }
        [Display(Name = "Heure du décollage")]
        [DataType(DataType.Time)]
        public DateTime FlightStart { get; set; }
        [Display(Name = "Heure de l'atterrissage")]
        [DataType(DataType.Time)]
        public DateTime FlightEnd { get; set; }
        public int PilotID { get; set; }
        public int ParaglidingID { get; set; }
        public int SiteID { get; set; }
        public Pilot Pilot { get; set; }
        public Paragliding Paragliding { get; set; }
        public Site Site { get; set; }


    }
}