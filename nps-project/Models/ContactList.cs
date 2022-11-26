using System.ComponentModel.DataAnnotations;

namespace nps_project.Models
{
    public class ContactList
    {
#pragma warning disable CS8618 // Non-nullable property 'phoneNumbers' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<PhoneNumber> phoneNumbers { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'phoneNumbers' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'emailAddresses' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<EmailAddress> emailAddresses { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'emailAddresses' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

    }
}
