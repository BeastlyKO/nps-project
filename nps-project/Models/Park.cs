#pragma warning disable

namespace nps_project.Models
{
    public class Park
    {
        //states which park can be found in
        public string states { get; set; }
        
        //weather information of park
        public string weatherInfo { get; set; }
 
        //information on directions to park
        public string directionsInfo { get; set; }
 
        //list of addresses for park
        public List<Address> addresses { get; set; }
 
        //list of entrance fees
        public List<EntranceFee> entranceFees { get; set; }
 
        //list of topics associated with park
        public List<Topic> topics { get; set; }
 
        //Park name
        public string name { get; set; }
 
        //latitude of parks location
        public string latitude { get; set; }
 
        //list of activities associated with park
        public List<Activity> activities { get; set; }

        //list of operating hours for park
        public List<OperatingHours> operatingHours { get; set; }

        //URL for park website
        public string url { get; set; }
 
        //longitude of parks location
        public string longitude { get; set; }
 
        //list of contact information for park
        public ContactList contacts { get; set; }
 
        //list of entrance passes for park
        public List<EntrancePass> entrancePasses { get; set; }
 
        //The park code associated to the park
        public string parkCode { get; set; }
        
        //The park's designation
        public string designation { get; set; }

        //List of images of the park
        public List<Image> images { get; set; }

        //Full name of the park
        public string fullName { get; set; }
 
        //Both longitude and latitdue of the park's location
        public string latLong { get; set; }

        //The park's id
        public string id { get; set; }

        //URL for directions to the park
        public string directionsUrl { get; set; }

        //Description of the park
        public string desctiption { get; set; }

    }
}
