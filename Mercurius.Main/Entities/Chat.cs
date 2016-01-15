using System.Collections.Generic;

namespace Mercurius.Main.Entities
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
