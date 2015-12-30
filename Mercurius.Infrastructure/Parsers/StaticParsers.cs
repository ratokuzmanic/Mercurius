using System;
using System.Globalization;
using System.Linq;
using Mercurius.Main;

namespace Mercurius.Infrastructure.Parsers
{
    public static class StaticParsers
    {
        public static string ParsePhoneNumber(string source)
        {
            if (source.ElementAt(0) == '+')
            {
                return "0" + source.Substring(source.IndexOf("+") + 4);
            }
            return source;
        }

        public static MessageStatus ParseMessageStatus(string source)
        {
            if (source.Equals("INBOX"))
            {
                return MessageStatus.Received;
            }
            return MessageStatus.Sent;
        }

        public static DateTime ParseDateTime(string source, string format)
        {
            return DateTime.ParseExact(source, format, CultureInfo.InvariantCulture);
        }
    }
}