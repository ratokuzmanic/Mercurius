﻿using System.Collections.Generic;

namespace Mercurius.Data.Models
{
    public class Chat
    {
        public Contact              Interlocutor    { get; private set; }
        public IEnumerable<Message> Messages        { get; private set; }

        public Chat
        (
            Contact                 interlocutor,
            IEnumerable<Message>    messages
        )
        {
            this.Interlocutor = interlocutor;
            this.Messages     = messages;
        }
    }
}