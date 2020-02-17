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
        public DateTime DateOfCommissioning { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfLastRevision { get; set; }
        public int ModelParaglidingID { get; set; }
        public ModelParagliding ModelParagliding { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
