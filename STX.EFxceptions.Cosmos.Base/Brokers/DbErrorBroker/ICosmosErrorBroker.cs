// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using STX.EFxceptions.Abstractions.Brokers.DbErrorBroker;

namespace STX.EFxceptions.Cosmos.Base.Brokers.DbErrorBroker
{
    public interface ICosmosErrorBroker : IDbErrorBroker<CosmosException>
    { }
}
