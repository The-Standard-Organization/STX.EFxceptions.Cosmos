// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using STX.EFxceptions.Abstractions.Models.Exceptions;
using STX.EFxceptions.Cosmos.Base.Models.Exceptions;

namespace STX.EFxceptions.Cosmos.Base.Services.Foundations
{
    public partial class CosmosEFxceptionService
    {
        public delegate void ReturningExceptionFunction();

        public void TryCatch(ReturningExceptionFunction returningExceptionFunction)
        {
            try
            {
                returningExceptionFunction();
            }
            catch (AuthenticationFailedCosmosException authenticationFailedCosmosException)
            {
                throw new AuthenticationFailedCosmosException(authenticationFailedCosmosException.Message);
            }
            catch (AuthorizationFailedCosmosException authorizationFailedCosmosException)
            {
                throw new AuthorizationFailedCosmosException(authorizationFailedCosmosException.Message);
            }
            catch (ResourceNotFoundCosmosException resourceNotFoundCosmosException)
            {
                throw new ResourceNotFoundCosmosException(resourceNotFoundCosmosException.Message);
            }
            catch (RequestTimeoutCosmosException requestTimeoutCosmosException)
            {
                throw new RequestTimeoutCosmosException(requestTimeoutCosmosException.Message);
            }
            catch (DuplicateKeyCosmosException duplicateKeyCosmosException)
            {
                throw new DuplicateKeyException(duplicateKeyCosmosException.Message, duplicateKeyCosmosException);
            }
            catch (PreconditionFailedCosmosException preconditionFailedCosmosException)
            {
                throw new PreconditionFailedCosmosException(preconditionFailedCosmosException.Message);
            }
            catch (PayloadTooLargeCosmosException payloadTooLargeCosmosException)
            {
                throw new PayloadTooLargeCosmosException(payloadTooLargeCosmosException.Message);
            }
            catch (ResourceLockedCosmosException resourceLockedCosmosException)
            {
                throw new ResourceLockedCosmosException(resourceLockedCosmosException.Message);
            }
            catch (DependencyFailedCosmosException dependencyFailedCosmosException)
            {
                throw new DependencyFailedCosmosException(dependencyFailedCosmosException.Message);
            }
            catch (TooManyRequestsCosmosException tooManyRequestsCosmosException)
            {
                throw new TooManyRequestsCosmosException(tooManyRequestsCosmosException.Message);
            }
            catch (InternalServerCosmosException internalServerCosmosException)
            {
                throw new InternalServerCosmosException(internalServerCosmosException.Message);
            }
            catch (ServiceUnavailableCosmosException serviceUnavailableCosmosException)
            {
                throw new ServiceUnavailableCosmosException(serviceUnavailableCosmosException.Message);
            }
        }

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
                case 409:
                    throw new DuplicateKeyCosmosException(message);
                case 412:
                    throw new PreconditionFailedCosmosException(message);
                case 413:
                    throw new PayloadTooLargeCosmosException(message);
                case 423:
                    throw new ResourceLockedCosmosException(message);
                case 424:
                    throw new DependencyFailedCosmosException(message);
                case 429:
                    throw new TooManyRequestsCosmosException(message);
                case 500:
                    throw new InternalServerCosmosException(message);
                case 503:
                    throw new ServiceUnavailableCosmosException(message);
            }
        }
    }
}
