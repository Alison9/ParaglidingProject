using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Paraglider
    {
        [Display(Name="Numéro du parapente")]
        public int ID { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de mise en service")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime CommissioningDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de la dernière révision")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime LastRevisionDate { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Numéro du modèle")]
        public int ParagliderModelID { get; set; }

        public ParagliderModel ParagliderModel { get; set; }

        [Display(Name="Historique des vols")]
        public ICollection<Flight> Flights { get; set; }
    }
}
