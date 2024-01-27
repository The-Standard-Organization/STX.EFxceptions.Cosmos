// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net;
using Microsoft.Azure.Cosmos;
using STX.EFxceptions.Cosmos.Base.Models.Exceptions;
using Xunit;

namespace STX.EFxceptions.Cosmos.Base.Tests.Unit.Services.Foundations
{
    public partial class CosmosEfxceptionServiceTests
    {
        [Fact]
        public void ShouldThrowCosmosExceptionIfStatusCodeIsNotRecognized()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Unused;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<CosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowAuthenticationFailedException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Unauthorized;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<AuthenticationFailedException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowAuthorizationFailedException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Forbidden;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<AuthorizationFailedException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }
    }
}
