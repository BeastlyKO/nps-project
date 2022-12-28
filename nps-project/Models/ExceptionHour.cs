#pragma warning disable
namespace nps_project.Models
{
    public class ExceptionHour
    {
        //Hours which are considered exceptions
        public Hours exceptionHours { get; set; }
 
        //Start date when exception hours are applied
        public string startDate { get; set; }
 
        //name for exception hours
        public string name { get; set; }
 
        //End for exception hours
        public string endDate { get; set; }
 
    }
}
