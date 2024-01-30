// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Services.Foundations
{
    public partial class CosmosEFxceptionService
    {
        private void ValidateInnerException(DbUpdateException dbUpdateException)
        {
            if (dbUpdateException.InnerException is null)
            {
                throw dbUpdateException;
            }
        }
    }
}
