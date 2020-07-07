using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Levels.NS.TransfertObjects
{
   public class LevelPatchDto
    {
        public string Name { get; set; }
        public string skill { get; set; }
      
        public bool validateBussinseLogic()
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Length >= 15 ) return false;
            if (string.IsNullOrEmpty(skill)) return false;
           
            return true;
        }
    }
}
