using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Paragliding
    {
        [Display(Name="Numéro du parapente")]
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de mise en service")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DateOfCommissioning { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de la dernière révision")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DateOfLastRevision { get; set; }
        [Display(Name = "Numéro du modèle")]
        public int ModelParaglidingID { get; set; } 
        public ModelParagliding ModelParagliding { get; set; }
        [Display(Name="Historique des vols")]
        public ICollection<Flight> Flights { get; set; }
    }
}
