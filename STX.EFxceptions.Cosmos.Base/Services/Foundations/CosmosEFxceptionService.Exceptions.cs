﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
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
            catch (DuplicateKeyCosmosException duplicateKeyCosmosException)
            {
                throw new DuplicateKeyException(
                    message: duplicateKeyCosmosException.Message,
                    innerException: duplicateKeyCosmosException);
            }
            catch (DbUpdateException)
            {
                throw;
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
