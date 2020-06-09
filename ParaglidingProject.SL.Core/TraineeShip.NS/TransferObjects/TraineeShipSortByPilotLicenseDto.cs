using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects
{
    public class TraineeShipSortByPilotLicenseDto
    {
        public int traineeShipId { get; set; }
        public int LicenseId { get; set; }
        public string LicenseTitle { get; set; }

    }
}
