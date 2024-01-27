// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using STX.EFxceptions.Core;
using STX.EFxceptions.Cosmos.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.Cosmos.Base.Services.Foundations;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;
using STX.EFxceptions.Interfaces.Services.EFxceptions;

namespace STX.EFxceptions.Cosmos
{
    public class EFxceptionsContext : DbContextBase<CosmosException>
    {
        protected override IDbErrorBroker<CosmosException> CreateErrorBroker() =>
            new CosmosErrorBroker();

        protected override IEFxceptionService<CosmosException> CreateEFxceptionService(
            IDbErrorBroker<CosmosException> errorBroker) => new CosmosEFxceptionService(errorBroker);
    }
}
