// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using STX.EFxceptions.Identity.Cosmos.Tests.Acceptance.Models.Clients;
using Xunit;

namespace STX.EFxceptions.Identity.Cosmos.Tests.Acceptance
{
    public partial class EFxceptionsIdentityContextTests
    {
        [Fact]
        public void ShouldSaveChangesSuccessfully()
        {
            // given
            var client = new Client
            {
                Id = new Guid("e02a866b-1266-4033-93a2-ea94ac457ee8")
            };

            // when
            context.Clients.Add(client);
            context.SaveChanges();

            // then
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}
