// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class PayloadTooLargeCosmosException : DbUpdateException
    {
        public PayloadTooLargeCosmosException(string message) : base(message) { }

        public PayloadTooLargeCosmosException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
