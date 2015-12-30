using System.Linq;
using Mercurius.Main;

using client  = Mercurius.Presentation.ViewModel;
using adaptee = Mercurius.Main.Models;

namespace Mercurius.Presentation.ViewModel
{
    public class Adapter
    {
        public static client::ViewModelMessage Request(adaptee::Message message)
        {
            return new ViewModelMessage()
            {
                SendersName = message.MessageStatus == MessageStatus.Received
                            ? message.InterlocutorsName
                            : "Ja",
                Content     = message.Content,
                Time        = $"{message.Timestamp.ToString("d.M.yyyy. u H:mm")}h"
            };
        }

        public static client::ViewModelChat Request(adaptee::Chat chat)
        {
            return new ViewModelChat()
            {
                InterlocutorName = chat.Interlocutor.FullName,
                PhoneNumber      = chat.Interlocutor.PhoneNumber,
                NumberOfMessages = chat.Messages.Count(),
                Messages         = chat.Messages.Select(Adapter.Request).ToList()
            };
        }
    }
}
