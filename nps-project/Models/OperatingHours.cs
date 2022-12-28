#pragma warning disable
namespace nps_project.Models
{
    public class OperatingHours
    {
        //hours which are exceptions to the normal operating hours
        List<ExceptionHour> exceptions { get; set; }

        //description for operating hours
        public string description { get; set; }

        //the current hours of operation
        public Hours standardHours { get; set; }

        //name for operating hours
        public string name { get; set; }

    }
}
