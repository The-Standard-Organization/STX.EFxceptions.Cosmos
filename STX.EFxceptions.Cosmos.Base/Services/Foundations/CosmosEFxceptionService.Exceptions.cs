// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using STX.EFxceptions.Cosmos.Base.Models.Exceptions;

namespace STX.EFxceptions.Cosmos.Base.Services.Foundations
{
    public partial class CosmosEFxceptionService
    {
        private void ConvertAndThrowMeaningfulException(int cosmosErrorCode, string message)
        {
            switch (cosmosErrorCode)
            {
                case 401:
                    throw new AuthenticationFailedException(message);
                case 403:
                    throw new AuthorizationFailedException(message);
                case 404:
                    throw new ResourceNotFoundException(message);
            }
        }
    }
}
