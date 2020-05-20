
namespace ParaglidingProject.Models
{
   public class PilotTraineeship
    {
        public int PilotID { get; set; }
        public int TraineeshipID { get; set; }
        
        public Pilot Pilot { get; set; }
        public Traineeship Traineeship { get; set; }


    }
}
