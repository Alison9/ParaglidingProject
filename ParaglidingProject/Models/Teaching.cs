﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Teaching
    {
        public int TeachingID { get; set; }
        public int PilotID { get; set; }
        public int CourseID { get; set; }
        public Pilot Pilot { get; set; }
        public Course Course { get; set; }

    }
}
