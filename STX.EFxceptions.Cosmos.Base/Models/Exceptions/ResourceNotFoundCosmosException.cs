// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class ResourceNotFoundCosmosException : DbUpdateException
    {
        public ResourceNotFoundCosmosException(string message) : base(message) { }
    }
}
