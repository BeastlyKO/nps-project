#pragma warning disable

namespace nps_project.Models
{
    //Object which will contain data obtained from API
    public class ListOfParks
    {
        //total # of parks collected
        public string total { get; set; }

        //list of park objects
        public List<Park> data { get; set; }

        //limit of parks gathered (default is 50 if accessing large data)
        public string limit { get; set; }

        
        public string start { get; set; }


    }
}
