// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class TooManyRequestsCosmosException : DbUpdateException
    {
        public TooManyRequestsCosmosException(string message) : base(message) { }

        public TooManyRequestsCosmosException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
