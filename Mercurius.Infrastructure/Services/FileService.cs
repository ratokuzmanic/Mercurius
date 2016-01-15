using System.IO;
using Mercurius.Infrastructure.Parsers;
using Mercurius.Main.Entities;

namespace Mercurius.Infrastructure.Services
{
    public static class FileService
    {
        public static Message ReadMessage(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            var message = VmgFormatParser.Parse(lines);

            return message;
        } 
    }
}