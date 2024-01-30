// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Cosmos.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.Cosmos.Base.Services.Foundations;
using STX.EFxceptions.Identity.Core;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;
using STX.EFxceptions.Interfaces.Services.EFxceptions;

namespace STX.EFxceptions.Identity.Cosmos
{
    public class EFxceptionsIdentityContext<TUser, TRole, TKey>
        : IdentityDbContextBase<TUser, TRole, TKey, IdentityUserClaim<TKey>, IdentityUserRole<TKey>,
            IdentityUserLogin<TKey>, IdentityRoleClaim<TKey>, IdentityUserToken<TKey>, CosmosException>
       where TUser : IdentityUser<TKey>
       where TRole : IdentityRole<TKey>
       where TKey : IEquatable<TKey>
    {
        public EFxceptionsIdentityContext(DbContextOptions options) : base(options)
        { }

        protected EFxceptionsIdentityContext() : base()
        { }

        protected override IDbErrorBroker<CosmosException> CreateErrorBroker() =>
            new CosmosErrorBroker();

        protected override IEFxceptionService CreateEFxceptionService(
            IDbErrorBroker<CosmosException> errorBroker)
        {
            return new CosmosEFxceptionService(errorBroker);
        }
    }

    public class EFxceptionsIdentityContext<
        TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        : IdentityDbContextBase<TUser, TRole, TKey,
            TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, CosmosException>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
    {
        public EFxceptionsIdentityContext(DbContextOptions options) : base(options)
        { }

        protected EFxceptionsIdentityContext() : base()
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
