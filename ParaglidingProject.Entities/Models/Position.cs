using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Position
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int PilotID { get; set; }
        public Pilot Pilot { get; set; }

    }
}