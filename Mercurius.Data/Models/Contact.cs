using Newtonsoft.Json;

namespace Mercurius.Data.Models
{
    public class Contact
    {
        [JsonProperty("Full name")]
        public string FullName    { get; private set; }

        [JsonProperty("Phone number")]
        public string PhoneNumber { get; private set; }

        public Contact
        (
            string fullName,
            string phoneNumber
        )
        {
            this.FullName    = fullName;
            this.PhoneNumber = phoneNumber;
        }
    }
}
