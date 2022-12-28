#pragma warning disable
namespace nps_project.Models
{
    public class Address
    {
        //Address postal code
        public string postalCode { get; set; }
 
        //City which the Address is located at
        public string city { get; set; }
 

        //The state code for where the Address is located at
        public string stateCode { get; set; }

        //Typicall the street of the address
        public string line1 { get; set; }
 
        // the type of address (Mailing or Physical Address)
        public string type { get; set; }

        //part of the address
        public string line3 { get; set; }
 
        //part of the address
        public string line2 { get; set; }

    }
}
