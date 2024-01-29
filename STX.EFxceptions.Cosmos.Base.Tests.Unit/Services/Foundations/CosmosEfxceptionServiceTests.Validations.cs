// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace STX.EFxceptions.Cosmos.Base.Tests.Unit.Services.Foundations
{
    public partial class CosmosEfxceptionServiceTests
    {
        [Fact]
        public void ShouldThrowDbUpdateExceptionIfCosmosExceptionWasNull()
        {
            // given
            var dbUpdateException = new DbUpdateException(null, default(Exception));

            // when . then
            Assert.Throws<DbUpdateException>(() =>
                this.cosmosEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            this.cosmosErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(It.IsAny<CosmosException>()),
                    Times.Never);
        }
    }
}
