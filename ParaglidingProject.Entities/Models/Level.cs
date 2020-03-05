using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Level
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public int DifficultyNumber { get; set; }
        public ICollection<License> Licenses { get; set; }
        public ICollection<Site> Sites { get; set; }
    }
}
