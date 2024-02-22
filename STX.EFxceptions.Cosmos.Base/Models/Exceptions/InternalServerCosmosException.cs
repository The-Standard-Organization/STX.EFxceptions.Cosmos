// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class InternalServerCosmosException : DbUpdateException
    {
        public InternalServerCosmosException(string message) : base(message) { }

        public InternalServerCosmosException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
