using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class License
    {
        public int ID { get; set; }
        [Display(Name ="Brevet délivré")]
        public string Title { get; set; }
        public int LevelID { get; set; }
        public ICollection<Possession> Possessions { get; set; }
        public ICollection<Traineeship> Traineeships { get; set; }
        public Level Level { get; set; }
    }
}
