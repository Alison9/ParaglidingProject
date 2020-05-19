using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class ParagliderModel
    {
        [Display(Name="Numero du modèle")]
        public int ID { get; set; }
        [Display(Name = "Taille")]
        public string Size { get; set; }
        [Display(Name = "Poids Maximum du pilote")]
        public int MaxWeightPilot { get; set; }
        [Display(Name = "Poids minimum du pilote")]
        public int MinWeightPilot { get; set; }
        [Display(Name = "Numéro d'homologation du modèle")]
        public string ApprovalNumber { get; set; }

        [Display(Name = "Date d'homologation")]
        [DataType(DataType.Date)]
        public DateTime ApprovalDate { get; set; }

        public bool IsActive { get; set; }
        [Display(Name = "Parapente")]
        public ICollection<Paraglider> Paragliders { get; set; }
    }
}
