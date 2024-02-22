// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class DuplicateKeyCosmosException : Exception
    {
        public DuplicateKeyCosmosException(string message) : base(message) { }

        public DuplicateKeyCosmosException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
