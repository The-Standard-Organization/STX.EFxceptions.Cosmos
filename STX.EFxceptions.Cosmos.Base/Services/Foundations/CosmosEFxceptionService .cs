// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using STX.EFxceptions.Cosmos.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;

namespace STX.EFxceptions.Cosmos.Base.Services.Foundations
{
    public partial class CosmosEFxceptionService : ICosmosEFxceptionService
    {
        private readonly IDbErrorBroker<CosmosException> cosmosErrorBroker;

        public CosmosEFxceptionService(IDbErrorBroker<CosmosException> cosmosErrorBroker) =>
            this.cosmosErrorBroker = cosmosErrorBroker;

        public void ThrowMeaningfulException(CosmosException cosmosException)
        {
            int cosmosErrorCode = this.cosmosErrorBroker.GetErrorCode(cosmosException);
            ConvertAndThrowMeaningfulException(cosmosErrorCode, cosmosException.Message);
            throw cosmosException;
        }
    }
}
