// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class AuthorizationFailedCosmosException : DbUpdateException
    {
        public AuthorizationFailedCosmosException(string message) : base(message) { }

        public AuthorizationFailedCosmosException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
