using System;
using Newtonsoft.Json;

namespace Mercurius.Data.Models
{
    public class Message
    {
        [JsonProperty("Interlocutors name")]
        public string        InterlocutorsName        { get; private set; }

        [JsonProperty("Interlocutors phone number")]
        public string        InterlocutorsPhoneNumber { get; private set; }

        [JsonProperty("Content")]
        public string        Content                  { get; private set; }

        [JsonProperty("Timestamp")]
        public DateTime      Timestamp                { get; private set; }

        [JsonProperty("Message status")]
        public int           MessageStatus            { get; private set; }

        public Message
        (
            string        interlocutorsName, 
            string        interlocutorsPhoneNumber,
            string        content,
            DateTime      timestamp,
            int           status
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
