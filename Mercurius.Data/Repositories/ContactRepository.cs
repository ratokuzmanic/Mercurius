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
            if (!DoesContactExist(newContact.PhoneNumber))
                _contactStorageService.AddItem(newContact);
        }

        private bool DoesContactExist(string phoneNumber)
        {
            var allContacts = GetAll(); 

            return allContacts
                .Any(contact => contact.PhoneNumber == phoneNumber);
        }
    }
}