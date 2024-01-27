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
                    throw new AuthenticationFailedCosmosException(message);
                case 403:
                    throw new AuthorizationFailedCosmosException(message);
                case 404:
                    throw new ResourceNotFoundCosmosException(message);
                case 408:
                    throw new RequestTimeoutCosmosException(message);
                case 412:
                    throw new PreconditionFailedCosmosException(message);
            }
        }
    }
}
