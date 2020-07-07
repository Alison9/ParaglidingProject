using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects
{
    public class ParagliderPatchDto
    {
        public string Name { get; set; }
        public DateTime LastRevision { get; set; }

        public bool ValidateBusinessLogic()
        {
            if (LastRevision > DateTime.Now) return false;
            return true;
        }
    }
}
