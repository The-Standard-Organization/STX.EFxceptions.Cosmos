﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<DbUpdateException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<DuplicateKeyException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<AuthenticationFailedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<AuthorizationFailedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<ResourceNotFoundCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<RequestTimeoutCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<PreconditionFailedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<PayloadTooLargeCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<ResourceLockedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<DependencyFailedCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<TooManyRequestsCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<InternalServerCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
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

            this.cosmosErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(cosmosException))
                    .Returns((int)cosmosStatusCode);

            // when . then
            Assert.Throws<ServiceUnavailableCosmosException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
    }
}
