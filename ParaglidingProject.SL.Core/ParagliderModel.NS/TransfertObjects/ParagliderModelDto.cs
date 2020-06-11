using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects
{
  public class ParagliderModelDto
  {
    public int ID { get; set; }
    public string Size { get; set; }
    public decimal MaxWeightPilot { get; set; }//Rien dans Models configuration
    public decimal MinWeightPilot { get; set; } 
    public string ApprovalNumber { get; set; }
    public DateTime ApprovalDate { get; set; }
    public bool IsActive { get; set; }
  }
}
