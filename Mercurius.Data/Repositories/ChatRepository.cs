using System.Collections.Generic;
using System.Linq;
using Mercurius.Data.Models;

namespace Mercurius.Data.Repositories
{
    public class ChatRepository
    {
        private readonly ContactRepository _contactRepository;
        private readonly MessageRepository _messageRepository;

        public ChatRepository()
        {
            _contactRepository = new ContactRepository();
            _messageRepository = new MessageRepository();
        }

        public void Create(Message newMessage)
        {
            _contactRepository.Create(new Contact(newMessage.InterlocutorsName, newMessage.InterlocutorsPhoneNumber));
            _messageRepository.Create(newMessage);
        }

        public IEnumerable<Chat> GetAll()
        {
            var allChats = new List<Chat>();
            var allContacts = _contactRepository.GetAll();
            
            foreach (var contact in allContacts)
            {
                var allMessages = _messageRepository.GetAll_SortedByDateTime()
                    .Where(message => message.InterlocutorsPhoneNumber == contact.PhoneNumber);
                allChats.Add(new Chat(contact, allMessages));
            }
            
            return allChats;
        }
    }
}