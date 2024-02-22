// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class ResourceNotFoundCosmosException : DbUpdateException
    {
        public ResourceNotFoundCosmosException(string message) : base(message) { }

        public ResourceNotFoundCosmosException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
