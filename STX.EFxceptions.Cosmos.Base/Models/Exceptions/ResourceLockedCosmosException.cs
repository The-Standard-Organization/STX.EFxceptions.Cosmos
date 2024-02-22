// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class ResourceLockedCosmosException : DbUpdateException
    {
        public ResourceLockedCosmosException(string message) : base(message) { }
    }
}
