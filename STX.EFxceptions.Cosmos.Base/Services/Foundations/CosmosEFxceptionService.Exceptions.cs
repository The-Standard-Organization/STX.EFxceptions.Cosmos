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
                case 408:
                    throw new RequestTimeoutException(message);
                case 409:
                    throw new DuplicateKeyException(message);
                case 412:
                    throw new PreconditionFailedException(message);
                case 413:
                    throw new PayloadTooLargeException(message);
                case 423:
                    throw new ResourceLockedException(message);
                case 424:
                    throw new DependencyFailedException(message);
                case 429:
                    throw new TooManyRequestsException(message);
                case 500:
                    throw new InternalServerException(message);
                case 503:
                    throw new ServiceUnavailableException(message);
            }
        }
    }
}
