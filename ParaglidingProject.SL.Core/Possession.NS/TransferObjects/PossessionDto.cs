using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace ParaglidingProject.SL.Core.Possession.NS.TransferObjects
{
   public class PossessionDto
    {
       
        public int PilotID { get; set; }
        public int LicenseID { get; set; }
        public DateTime ExamDate { get; set; }
        public bool IsSucceeded { get; set; }
        public bool IsActive { get; set; }
    }
}
