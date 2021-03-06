﻿using System.Linq;

using entity = Mercurius.Main.Entities;
using data   = Mercurius.Data.Models;

namespace Mercurius.Infrastructure.Mappers
{
    public static class ChatMapper
    {
        public static entity::Chat Map(data::Chat chat)
        {
            return new entity::Chat
                (
                    ContactMapper.Map(chat.Interlocutor),
                    chat.Messages.Select(MessageMapper.Map).ToList()
                );
        }

        public static data::Chat Map(entity::Chat chat)
        {
            return new data::Chat
                (
                    ContactMapper.Map(chat.Interlocutor),
                    chat.Messages.Select(MessageMapper.Map).ToList()
                );
        }

    }
}
