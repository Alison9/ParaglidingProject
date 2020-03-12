using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Position
    {
        public int ID { get; set; }
        [Display(Name = "Position")]
        public string Name { get; set; }
        [Display(Name="Pilote")]
        public int PilotID { get; set; }
        public Pilot Pilot { get; set; }

    }
}