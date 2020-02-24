using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Paragliding
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de mise en service")]
        [Required]
        public DateTime DateOfCommissioning { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de la dernière révision")]
        [Required]
        public DateTime DateOfLastRevision { get; set; }
        public int ModelParaglidingID { get; set; }
        [Display(Name = "Modèle")]
        public ModelParagliding ModelParagliding { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
