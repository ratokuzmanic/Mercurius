using entity = Mercurius.Main.Entities;
using data   = Mercurius.Data.Models;

namespace Mercurius.Infrastructure.Mappers
{
    public static class ContactMapper
    {
        public static entity::Contact Map(data::Contact contact)
        {
            return new entity::Contact
                (
                    contact.FullName,
                    contact.PhoneNumber
                );
        }

        public static data::Contact Map(entity::Contact contact)
        {
            return new data::Contact
                (
                    contact.FullName,
                    contact.PhoneNumber
                );
        }
    }
}
