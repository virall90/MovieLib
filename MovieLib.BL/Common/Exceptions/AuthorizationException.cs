using System;
using MovieLib.BL.Common.Interfaces;

namespace MovieLib.BL.Common.Exceptions
{
    public class AuthorizationException : Exception, IHasUserMessage
    {
        public AuthorizationException(string userMessage)
        {
            UserMessage = userMessage;
        }

        public string UserMessage { get; }
    }
}