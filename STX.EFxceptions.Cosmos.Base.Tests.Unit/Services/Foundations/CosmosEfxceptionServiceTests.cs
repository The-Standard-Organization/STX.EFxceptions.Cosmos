// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using System.Net;
using Moq;
using STX.EFxceptions.Cosmos.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.Cosmos.Base.Services.Foundations;
using System.Drawing.Printing;
using Tynamix.ObjectFiller;

namespace STX.EFxceptions.Cosmos.Base.Tests.Unit.Services.Foundations
{
    public partial class CosmosEfxceptionServiceTests
    {
        private readonly Mock<ICosmosErrorBroker> cosmosErrorBrokerMock;
        private readonly ICosmosEFxceptionService cosmosEFxceptionService;

        public CosmosEfxceptionServiceTests()
        {
            this.cosmosErrorBrokerMock = new Mock<ICosmosErrorBroker>();

            this.cosmosEFxceptionService = new CosmosEFxceptionService(
                cosmosErrorBroker: this.cosmosErrorBrokerMock.Object);
        }

        private CosmosException CreateCosmosException(HttpStatusCode cosmosStatusCode)
        {
            string randomMessage = GetRandomMessage();
            int randomNumber = GetRandomNumber();

            return new CosmosException(
                message: randomMessage,
                statusCode: cosmosStatusCode,
                subStatusCode: randomNumber,
                activityId: randomMessage,
                requestCharge: randomNumber);
        }

        private string GetRandomMessage() => new MnemonicString().GetValue();
        private int GetRandomNumber() => new IntRange(min: 0, max: 10).GetValue();
    }
}
