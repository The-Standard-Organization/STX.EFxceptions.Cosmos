// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Cosmos.Base.Models.Exceptions;
using STX.EFxceptions.Cosmos.Tests.Acceptance.Models;
using Xunit;

namespace STX.EFxceptions.Cosmos.Tests.Acceptance
{
    public partial class EFxceptionsContextTests
    {
        private readonly DbContextOptions<EFxceptionsContext> options;
        private readonly MyEFxceptionsContext context;

        public EFxceptionsContextTests()
        {
            options = new DbContextOptionsBuilder<EFxceptionsContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            this.context = new MyEFxceptionsContext(options);
        }
    }
}
