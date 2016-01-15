using System.Collections.Generic;
using System.Linq;
using Mercurius.Data.Repositories;
using Mercurius.Infrastructure.Mappers;
using Mercurius.Main.Entities;

namespace Mercurius.Infrastructure.Services
{
    public class StorageService
    {
        private readonly ChatRepository _chatRepository;

        public StorageService()
        {
            _chatRepository = new ChatRepository();
        }

        public void Create(string filePath)
        {
            var newMessage = FileService.ReadMessage(filePath);

            var messageDto = MessageMapper.Map(newMessage);
            _chatRepository.Create(messageDto);
        }

        public void Create(string[] filePaths)
        {
            foreach (var filePath in filePaths)
            {
                Create(filePath);
            }
        }

        public IList<Chat> GetAll()
        {
            var chatDto = _chatRepository.GetAll();
            return chatDto.Select(ChatMapper.Map).ToList();
        }
    }
}