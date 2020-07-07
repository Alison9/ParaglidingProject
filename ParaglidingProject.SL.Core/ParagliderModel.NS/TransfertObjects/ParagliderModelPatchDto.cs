using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects
{
    public class ParagliderModelPatchDto
    {
        public decimal MaxWeightPilot { get; set; }
        public decimal MinWeightPilot { get; set; }

        public bool ValidateBusinessLogic()
        {
            if (MaxWeightPilot < MinWeightPilot) return false;

            return true;
        }
    }
}
