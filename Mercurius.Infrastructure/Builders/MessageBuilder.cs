using System;
using Mercurius.Main;
using Mercurius.Main.Entities;

namespace Mercurius.Infrastructure.Builders
{
    public class MessageBuilder
    {
        public string        InterlocutorsName        { get; set; }
        public string        InterlocutorsPhoneNumber { get; set; }
        public string        Content                  { get; set; }
        public DateTime      Timestamp                { get; set; }
        public MessageStatus MessageStatus            { get; set; }
        
        public void Initialize()
        {
            InterlocutorsName        = null;
            InterlocutorsPhoneNumber = null;
            Content                  = null;
            Timestamp                = DateTime.MinValue;
            MessageStatus            = MessageStatus.Received;
        }

        public Message Build()
        {
            return new Message
            (
                InterlocutorsName        ?? "Anonimna poruka", 
                InterlocutorsPhoneNumber ?? "Skriveni broj",
                Content                  ?? "Prazna poruka",
                Timestamp,
                MessageStatus
            );
        }
    }
}
