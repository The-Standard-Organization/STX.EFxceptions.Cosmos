// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class ServiceUnavailableCosmosException : DbUpdateException
    {
        public ServiceUnavailableCosmosException(string message) : base(message) { }

        public ServiceUnavailableCosmosException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
