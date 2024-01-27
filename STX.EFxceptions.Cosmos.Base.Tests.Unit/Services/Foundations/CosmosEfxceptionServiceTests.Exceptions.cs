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
        public void ShouldThrowAuthenticationFailedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Unauthorized;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<AuthenticationFailedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowAuthorizationFailedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Forbidden;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<AuthorizationFailedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowResourceNotFoundCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.NotFound;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<ResourceNotFoundCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowRequestTimeoutCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.RequestTimeout;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<RequestTimeoutCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowPreconditionFailedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.PreconditionFailed;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<PreconditionFailedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowPayloadTooLargeCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.RequestEntityTooLarge;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<PayloadTooLargeCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowResourceLockedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Locked;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<ResourceLockedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowDependencyFailedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.FailedDependency;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<DependencyFailedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowTooManyRequestsCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.TooManyRequests;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<TooManyRequestsCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }

        [Fact]
        public void ShouldThrowInternalServerCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.InternalServerError;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<InternalServerCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(cosmosException));
        }
    }
}
