// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class PreconditionFailedCosmosException : DbUpdateException
    {
        public PreconditionFailedCosmosException(string message) : base(message) { }

        public PreconditionFailedCosmosException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
