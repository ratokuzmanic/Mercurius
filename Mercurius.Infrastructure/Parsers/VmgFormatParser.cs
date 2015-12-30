using Mercurius.Infrastructure.Builders;
using Mercurius.Main.Models;

namespace Mercurius.Infrastructure.Parsers
{
    public static class LineFormattingDetails
    {
        public static string Receiver       = "FN";
        public static string PhoneNumber    = "TEL;CELL;";
        public static string MessageStatus  = "X-IRMC-BOX";
        public static string ReceiveTime    = "Date";
        public static string Content        = "TEXT";

        public static string DateTimeFormatting = "yyyy.M.d.H.m.s";
    }

    public class VmgFormatParser
    {
        private static MessageBuilder _messageBuilder = new MessageBuilder();

        public static Message Parse(string[] source)
        {
            _messageBuilder.Initialize();

            foreach (var line in source)
            {
                var value = GetValue(line);

                if (line.Contains(LineFormattingDetails.Receiver))
                {
                    _messageBuilder.InterlocutorsName = QuotedPrintableParser.Parse(value);
                }
                else if (line.Contains(LineFormattingDetails.PhoneNumber))
                {
                    _messageBuilder.InterlocutorsPhoneNumber = StaticParsers.ParsePhoneNumber(value);
                }
                else if (line.Contains(LineFormattingDetails.MessageStatus))
                {
                    _messageBuilder.MessageStatus = StaticParsers.ParseMessageStatus(value);
                }
                else if (line.Contains(LineFormattingDetails.ReceiveTime))
                {
                    _messageBuilder.Timestamp = StaticParsers.ParseDateTime(value, LineFormattingDetails.DateTimeFormatting);
                }
                else if (line.Contains(LineFormattingDetails.Content))
                {
                    _messageBuilder.Content = QuotedPrintableParser.Parse(value);
                }
            }

            return _messageBuilder.Build();
        }

        private static string GetValue(string source)
        {
            return source.Substring(source.IndexOf(":") + 1);
        }
    }
}
