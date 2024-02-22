// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class DependencyFailedCosmosException : DbUpdateException
    {
        public DependencyFailedCosmosException(string message) : base(message) { }
    }
}
