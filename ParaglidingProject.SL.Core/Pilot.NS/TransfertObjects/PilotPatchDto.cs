using System;
using System.Linq;

namespace ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects
{
    public class PilotPatchDto
    {
        public string PhoneNumber { get; set; }
        public int Weight { get; set; } 

        public bool ValidateBusinessLogic()
        {
            if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber.Length != 10 || !PhoneNumber.All(char.IsDigit)) return false;
            if (Weight <= 0 || Weight > 530) return false;
            return true;
        }
    }
}
