// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using Moq;
using STX.EFxceptions.Cosmos.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.Cosmos.Base.Services.Foundations;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;
using STX.EFxceptions.Interfaces.Services.EFxceptions;
using Xunit;

namespace STX.EFxceptions.Cosmos.Tests.Unit
{
    public class EFxceptionsContextTests
    {
        private readonly Mock<EFxceptionsContext> eFxceptionsContext;
        private readonly Mock<IDbErrorBroker<CosmosException>> errorBrokerMock;
        private readonly Mock<IEFxceptionService<CosmosException>> eFxceptionServiceMock;

        public EFxceptionsContextTests()
        {
            this.errorBrokerMock = new Mock<IDbErrorBroker<CosmosException>>();
            this.eFxceptionServiceMock = new Mock<IEFxceptionService<CosmosException>>();
            this.eFxceptionsContext = new Mock<EFxceptionsContext>();
        }

        [Fact]
        public void ShouldReturnCosmosErrorBroker()
        {
           
        }
    }

}
