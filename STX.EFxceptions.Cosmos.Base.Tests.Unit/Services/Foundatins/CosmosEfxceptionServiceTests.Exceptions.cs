// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using System.Net;
using Xunit;

namespace STX.EFxceptions.Cosmos.Base.Tests.Unit.Services.Foundatins
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
    }
}
