namespace Mercurius.Main.Entities
{
    public class Contact
    {
        public string FullName    { get; private set; }
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
