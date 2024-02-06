// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class ResourceLockedException : Exception
    {
        public ResourceLockedException(string message) : base(message) { }
    }
}
