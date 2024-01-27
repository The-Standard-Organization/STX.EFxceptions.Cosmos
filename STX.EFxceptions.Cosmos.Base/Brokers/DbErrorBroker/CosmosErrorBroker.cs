// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;

namespace STX.EFxceptions.Cosmos.Base.Brokers.DbErrorBroker
{
    public class CosmosErrorBroker : ICosmosErrorBroker
    {
        public int GetErrorCode(CosmosException cosmosException) =>
            (int)cosmosException.StatusCode;
    }
}
