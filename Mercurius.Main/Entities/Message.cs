using System;

namespace Mercurius.Main.Entities
{
    public class Message
    {
        public string        InterlocutorsName        { get; private set; }
        public string        InterlocutorsPhoneNumber { get; private set; }
        public string        Content                  { get; private set; }
        public DateTime      Timestamp                { get; private set; }
        public MessageStatus MessageStatus            { get; private set; }

        public Message
        (
            string        interlocutorsName, 
            string        interlocutorsPhoneNumber,
            string        content,
            DateTime      timestamp,
            MessageStatus status
        )
        {
            this.InterlocutorsName        = interlocutorsName;
            this.InterlocutorsPhoneNumber = interlocutorsPhoneNumber;
            this.Content                  = content;
            this.Timestamp                = timestamp;
            this.MessageStatus            = status;
        }
    }
}
