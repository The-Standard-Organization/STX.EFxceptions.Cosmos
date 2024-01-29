// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Core;
using STX.EFxceptions.Cosmos.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.Cosmos.Base.Services.Foundations;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;
using STX.EFxceptions.Interfaces.Services.EFxceptions;

namespace STX.EFxceptions.Cosmos
{
    public class EFxceptionsContext : DbContextBase<CosmosException>
    {
        public EFxceptionsContext(DbContextOptions<EFxceptionsContext> options)
            : base(options)
        { }

        protected EFxceptionsContext()
            : base()
        { }

        protected override IDbErrorBroker<CosmosException> CreateErrorBroker() =>
            new CosmosErrorBroker();

        protected override IEFxceptionService<CosmosException> CreateEFxceptionService(
            IDbErrorBroker<CosmosException> errorBroker)
        {
            return new CosmosEFxceptionService(errorBroker);
        }
    }
}
