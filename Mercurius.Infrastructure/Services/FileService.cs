using System.IO;
using Mercurius.Infrastructure.Parsers;
using Mercurius.Main.Models;

namespace Mercurius.Infrastructure.Services
{
    public class FileService
    {
        public static Message ReadMessage(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            var message = VmgFormatParser.Parse(lines);

            return message;
        } 
    }
}