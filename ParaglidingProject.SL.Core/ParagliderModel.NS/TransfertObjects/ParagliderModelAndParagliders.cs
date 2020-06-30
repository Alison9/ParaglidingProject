using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects
{
    public class ParagliderModelAndParagliders
    {
        public ParagliderModelDto ParagliderModelDto { get; set; }
        public ICollection<ParagliderDto> ParagliderDto { get; set; }
    }
}
