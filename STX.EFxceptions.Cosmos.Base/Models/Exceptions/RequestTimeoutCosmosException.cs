// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class RequestTimeoutCosmosException : DbUpdateException
    {
        public RequestTimeoutCosmosException(string message) : base(message) { }

        public RequestTimeoutCosmosException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
