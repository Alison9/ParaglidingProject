using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Pilot
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Prénom")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Nom")]
        public string LastName { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Display(Name="Numéro de téléphone")]
        public string PhoneNumber { get; set; }

        [Display(Name ="Poids")]
        public int Weight { get; set; }
        public int? RoleID { get; set; }

        [Display(Name ="Fonction au sein du comité")]
        public Role? Role { get; set; }
        [Display(Name ="Est actif?")]
        public bool IsActif { get; set; }
        [Display(Name ="Vol(s)")]
        public ICollection<Flight> Flights { get; set; }
        [Display(Name ="Payements")]
        public ICollection<SubscriptionPayment> SubscriptionsPayments { get; set; }
        [Display(Name ="Cours suivi(s)")]
        public ICollection<TraineeshipPayment> TraineeshipPayments { get; set; }
        [Display(Name ="Cours donné(s)")]
        public ICollection<Teaching> Teachings { get; set; }
        [Display(Name ="Brevet(s) obtenu(s)")]
        public ICollection<Possession> Possessions { get; set; }
    }
}
