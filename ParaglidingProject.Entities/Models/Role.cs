using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Role
    {
        public int ID { get; set; }
        [Display(Name = "Role Administratif")]
        [StringLength(250)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [Display(Name="Pilote")]
        public int PilotID { get; set; }
        public Pilot Pilot { get; set; }

    }
}