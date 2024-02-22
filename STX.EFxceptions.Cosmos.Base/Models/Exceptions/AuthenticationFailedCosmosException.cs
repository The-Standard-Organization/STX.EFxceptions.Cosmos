// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class AuthenticationFailedCosmosException : DbUpdateException
    {
        public AuthenticationFailedCosmosException(string message) : base(message) { }

        public AuthenticationFailedCosmosException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
