using System;
using Microsoft.AspNetCore.Identity;

namespace MovieLib.BL.Common.Exceptions
{
    public class IdentityResultException : Exception
    {
        public IdentityResultException(IdentityResult identityResult)
        {
            IdentityResult = identityResult;
        }

        public IdentityResult IdentityResult { get; }
    }
}
