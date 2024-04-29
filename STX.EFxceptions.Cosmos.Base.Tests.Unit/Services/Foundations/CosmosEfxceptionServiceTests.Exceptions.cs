// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net;
using FluentAssertions;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Moq;
using STX.EFxceptions.Abstractions.Models.Exceptions;
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

            var dbUpdateException = new DbUpdateException(
                message: cosmosException.Message,
                innerException: cosmosException);

            DbUpdateException expectedDbUpdateException = dbUpdateException;

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when 
            DbUpdateException actualDbUpdateException =
                Assert.Throws<DbUpdateException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualDbUpdateException.Should()
                .BeEquivalentTo(
                expectation: expectedDbUpdateException,
                    config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();

        }

        [Fact]
        public void ShouldThrowDuplicateKeyCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Conflict;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var duplicateKeyCosmosException =
                new DuplicateKeyCosmosException(cosmosException.Message);

            var expectedDuplicateKeyException =
                new DuplicateKeyException(
                    message: duplicateKeyCosmosException.Message,
                    innerException: duplicateKeyCosmosException);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when 
            DuplicateKeyException actualDuplicateKeyException =
                Assert.Throws<DuplicateKeyException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualDuplicateKeyException.Should()
                .BeEquivalentTo(
                    expectation: expectedDuplicateKeyException,
                    config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowAuthenticationFailedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Unauthorized;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedAuthenticationFailedCosmosException =
                new AuthenticationFailedCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when
            AuthenticationFailedCosmosException actualAuthenticationFailedCosmosException =
                Assert.Throws<AuthenticationFailedCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualAuthenticationFailedCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedAuthenticationFailedCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowAuthorizationFailedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Forbidden;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedAuthorizationFailedCosmosException =
                new AuthorizationFailedCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when 
            AuthorizationFailedCosmosException actualAuthorizationFailedCosmosException =
                Assert.Throws<AuthorizationFailedCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualAuthorizationFailedCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedAuthorizationFailedCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowResourceNotFoundCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.NotFound;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedResourceNotFoundCosmosException =
                new ResourceNotFoundCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when 
            ResourceNotFoundCosmosException actualResourceNotFoundCosmosException =
                Assert.Throws<ResourceNotFoundCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualResourceNotFoundCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedResourceNotFoundCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }


        [Fact]
        public void ShouldThrowRequestTimeoutCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.RequestTimeout;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedRequestTimeoutCosmosException =
                new RequestTimeoutCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when
            RequestTimeoutCosmosException actualRequestTimeoutCosmosException =
                Assert.Throws<RequestTimeoutCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualRequestTimeoutCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedRequestTimeoutCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowPreconditionFailedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.PreconditionFailed;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedPreconditionFailedCosmosException =
                new PreconditionFailedCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when 
            PreconditionFailedCosmosException actualPreconditionFailedCosmosException =
                Assert.Throws<PreconditionFailedCosmosException>(() =>
                    this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualPreconditionFailedCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedPreconditionFailedCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowPayloadTooLargeCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.RequestEntityTooLarge;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedPayloadTooLargeCosmosException =
                new PayloadTooLargeCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when
            PayloadTooLargeCosmosException actualPayloadTooLargeCosmosException =
                Assert.Throws<PayloadTooLargeCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualPayloadTooLargeCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedPayloadTooLargeCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowResourceLockedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.Locked;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedResourceLockedCosmosException =
                new ResourceLockedCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when 
            ResourceLockedCosmosException actualResourceLockedCosmosException =
                Assert.Throws<ResourceLockedCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualResourceLockedCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedResourceLockedCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowDependencyFailedCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.FailedDependency;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedDependencyFailedCosmosException =
                new DependencyFailedCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when
            DependencyFailedCosmosException actualDependencyFailedCosmosException =
                Assert.Throws<DependencyFailedCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualDependencyFailedCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedDependencyFailedCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowTooManyRequestsCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.TooManyRequests;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedTooManyRequestsCosmosException =
               new TooManyRequestsCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when 
            TooManyRequestsCosmosException actualTooManyRequestsCosmosException =
                Assert.Throws<TooManyRequestsCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualTooManyRequestsCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedTooManyRequestsCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();

        }

        [Fact]
        public void ShouldThrowInternalServerCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.InternalServerError;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedInternalServerCosmosException =
                new InternalServerCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when 
            InternalServerCosmosException actualInternalServerCosmosException =
                Assert.Throws<InternalServerCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualInternalServerCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedInternalServerCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceUnavailableCosmosException()
        {
            // given
            HttpStatusCode cosmosStatusCode = HttpStatusCode.ServiceUnavailable;
            CosmosException cosmosException = CreateCosmosException(cosmosStatusCode);

            var dbUpdateException = new DbUpdateException(
               message: cosmosException.Message,
               innerException: cosmosException);

            var expectedServiceUnavailableCosmosException =
                new ServiceUnavailableCosmosException(cosmosException.Message);

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when 
            ServiceUnavailableCosmosException actualServiceUnavailableCosmosException =
                Assert.Throws<ServiceUnavailableCosmosException>(() =>
                    this.cosmosEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualServiceUnavailableCosmosException.Should()
                .BeEquivalentTo(
                expectation: expectedServiceUnavailableCosmosException,
                config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(cosmosException), Times.Once);

            this.cosmosErrorBrokerMock.VerifyNoOtherCalls();
        }
    }
}
