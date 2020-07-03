using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Subscription.NS.transferObjects
{
    public class SubscriptionAndPilotsDto
    {
        public SubscriptionDto SubscriptionDto { get; set; }
        public IReadOnlyCollection<PilotDto> pilotDtos { get; set; }
    }
}
