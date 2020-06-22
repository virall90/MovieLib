using System;
using MovieLib.BL.Common.Interfaces;

namespace MovieLib.BL.Common.Exceptions
{
    public class NotFoundException : Exception, IHasUserMessage
    {
        public NotFoundException(string userMessage)
        {
            UserMessage = userMessage;
        }

        public string UserMessage { get; }
    }
}
