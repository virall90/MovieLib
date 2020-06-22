using System;
using System.Linq;
using System.Security.Authentication;
using FluentValidation;
using MovieLib.BL.Common.Exceptions;
using MovieLib.BL.Common.Interfaces;
using MovieLib.BL.Common.Response;

namespace MovieLib.BL.Common.Extensions
{
    public static class ExceptionToErrorResultExtensions
    {
        public static ErrorListResponse GetErrorListResponseFromException(this Exception e) =>
            e switch
            {
                null => null,
                
                AggregateException ae when ae.InnerException != null
                => GetErrorListResponseFromException(ae.InnerException),

                AuthenticationException ae => ae.GetErrorListResponseFromValidationException(),
                
                ValidationException ve => ve.GetErrorListResponseFromValidationException(),

                ArgumentException ae => ae.GetErrorListResponseArgumentException(),

                IdentityResultException ire => ire.GetErrorListResponseIdentityResultException(),

                IHasUserMessage hum => hum.GetErrorListResponseIHasUserMessageException(),

                _ => throw new NotSupportedException()
            };

        public static ErrorListResponse GetErrorListResponseFromValidationException(this AuthenticationException e) =>
            new ErrorListResponse(e.Message);
        
        public static ErrorListResponse GetErrorListResponseFromValidationException(this ValidationException e) =>
            new ErrorListResponse(e.Errors.Select(failure => failure.ErrorMessage).ToList());

        public static ErrorListResponse GetErrorListResponseIHasUserMessageException(this IHasUserMessage e) =>
            new ErrorListResponse(e.UserMessage);

        public static ErrorListResponse GetErrorListResponseArgumentException(this ArgumentException e) =>
            new ErrorListResponse(e.Message);

        public static ErrorListResponse GetErrorListResponseIdentityResultException(this IdentityResultException e) =>
            new ErrorListResponse(e.IdentityResult.Errors.Select(error => error.Description)
                .ToList());
    }
}