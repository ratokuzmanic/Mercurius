using Mercurius.Main;

using entity = Mercurius.Main.Models;
using data   = Mercurius.Data.Models;

namespace Mercurius.Infrastructure.Mappers
{
    public class MessageMapper
    {
        public static entity::Message Map(data::Message message)
        {
            return new entity::Message
                (
                    message.InterlocutorsName,
                    message.InterlocutorsPhoneNumber,
                    message.Content,
                    message.Timestamp,
                    (MessageStatus)message.MessageStatus
                );
        }

        public static data::Message Map(entity::Message message)
        {
            return new data::Message
                (
                    message.InterlocutorsName,
                    message.InterlocutorsPhoneNumber,
                    message.Content,
                    message.Timestamp,
                    (int)message.MessageStatus
                );
        }
    }
}
