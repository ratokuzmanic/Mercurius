using System.Collections.Generic;
using System.Linq;
using Mercurius.Data.Models;

namespace Mercurius.Data.Repositories
{
    public class MessageRepository
    {
        private readonly JsonStorageService<Message> _messageStorageService;

        public MessageRepository()
        {
            _messageStorageService = new JsonStorageService<Message>();
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageStorageService.ReadAll();
        }

        public IEnumerable<Message> GetAll_SortedByDateTime()
        {
            var messageList = _messageStorageService.ReadAll().ToList();
            messageList.Sort((first, second) => first.Timestamp.CompareTo(second.Timestamp));
            return messageList;
        }

        public void Create(Message newMessage)
        {
            if (!DoesMessageExist(newMessage))
                _messageStorageService.AddItem(newMessage);
        }

        private bool DoesMessageExist(Message newMessage)
        {
            var allMessages = GetAll();

            return allMessages
                .Any(message => message.Equals(newMessage));
        }
    }
}