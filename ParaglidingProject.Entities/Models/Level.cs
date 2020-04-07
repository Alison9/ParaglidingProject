using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Level
    {
        
        public int ID { get; set; }
        [Display(Name = "Nom du niveau")]
        public string Name { get; set; }
        public string Skill { get; set; }
        [Display(Name = "Niveau du brevet")]
        public int DifficultyNumber { get; set; }
        public ICollection<License> Licenses { get; set; }
        public ICollection<Site> Sites { get; set; }
    }
}
