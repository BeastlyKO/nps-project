using System.ComponentModel.DataAnnotations;
#pragma warning disable
namespace nps_project.Models
{
    public class ContactList
    {
        //list of phone numbers for park
        public List<PhoneNumber> phoneNumbers { get; set; }
 
        //list of email addresses for park
        public List<EmailAddress> emailAddresses { get; set; }

    }
}
