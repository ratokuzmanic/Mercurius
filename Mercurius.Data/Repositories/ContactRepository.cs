using System.Collections.Generic;
using System.Linq;
using Mercurius.Data.Models;

namespace Mercurius.Data.Repositories
{
    public class ContactRepository
    {
        private readonly JsonStorageService<Contact> _contactStorageService;

        public ContactRepository()
        {
            _contactStorageService = new JsonStorageService<Contact>();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactStorageService.ReadAll();
        }

        public void Create(Contact newContact)
        {
            if (!DoesContactExist(newContact))
                _contactStorageService.AddItem(newContact);
        }

        private bool DoesContactExist(Contact newContact)
        {
            var allContacts = GetAll(); 

            return allContacts
                .Any(contact => contact.Equals(newContact));
        }
    }
}