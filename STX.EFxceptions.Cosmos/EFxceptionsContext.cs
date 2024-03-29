// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Core;
using STX.EFxceptions.Cosmos.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.Cosmos.Base.Services.Foundations;
using STX.EFxceptions.Abstractions.Brokers.DbErrorBroker;
using STX.EFxceptions.Abstractions.Services.EFxceptions;

namespace STX.EFxceptions.Cosmos
{
    public abstract class EFxceptionsContext : DbContextBase<CosmosException>
    {
        public EFxceptionsContext(DbContextOptions options)
            : base(options)
        { }

        protected EFxceptionsContext()
            : base()
        { }

        protected override IDbErrorBroker<CosmosException> CreateErrorBroker() =>
            new CosmosErrorBroker();

        protected override IEFxceptionService CreateEFxceptionService(
            IDbErrorBroker<CosmosException> errorBroker)
        {
            return new CosmosEFxceptionService(errorBroker);
        }
    }
}
