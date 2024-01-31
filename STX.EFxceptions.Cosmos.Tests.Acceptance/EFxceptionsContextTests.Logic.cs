// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using STX.EFxceptions.Cosmos.Base.Models.Exceptions;
using STX.EFxceptions.Cosmos.Tests.Acceptance.Models;
using Xunit;

namespace STX.EFxceptions.Cosmos.Tests.Acceptance
{
    public partial class EFxceptionsContextTests
    {
        [Fact]
        public void ShouldSaveChangesSuccessfully()
        {
            // given
            var client = new Client
            {
                Id = new Guid("e02a866b-1266-4033-93a2-ea94ac457ee8"),
            };

            // when
            context.Clients.Add(client);
            context.SaveChanges();

            // then
            context.Clients.Remove(client);
            context.SaveChanges();
        }

        [Fact]
        public void ShouldThrowDuplicateKeyExceptionOnSaveChanges()
        {
            // given
            var client = new Client
            {
                Id = new Guid("e02a866b-1266-4033-93a2-ea94ac457ee8"),
            };

            // when . then
            Assert.Throws<DuplicateKeyCosmosException>(() =>
            {
                try
                {
                    for (int i = 0; i < 2; i++)
                    {
                        context.Clients.Add(client);
                        context.SaveChanges();
                    }
                }
                catch (ArgumentException argumentException)
                {
                    throw new DuplicateKeyCosmosException(argumentException.Message);
                }
                finally
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
            });
        }
    }
}
