﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Teaching
    {
        public int ID { get; set; }
        public int PilotID { get; set; }
        public int CourseID { get; set; }
        public ICollection<Pilot> Pilots { get; set; }
        public Course Course { get; set; }

    }
}
