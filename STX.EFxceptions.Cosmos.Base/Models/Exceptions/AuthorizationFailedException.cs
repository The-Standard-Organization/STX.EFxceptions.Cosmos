// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException(string message) : base(message) { }
    }
}
