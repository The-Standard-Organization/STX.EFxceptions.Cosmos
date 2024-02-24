// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Abstractions.Brokers.DbErrorBroker;

namespace STX.EFxceptions.Cosmos.Base.Services.Foundations
{
    public partial class CosmosEFxceptionService : ICosmosEFxceptionService
    {
        private readonly IDbErrorBroker<CosmosException> cosmosErrorBroker;

        public CosmosEFxceptionService(IDbErrorBroker<CosmosException> cosmosErrorBroker) =>
            this.cosmosErrorBroker = cosmosErrorBroker;

        public void ThrowMeaningfulException(DbUpdateException dbUpdateException) =>
        TryCatch(() =>
        {
            ValidateInnerException(dbUpdateException);
            CosmosException cosmosException = GetCosmosException(dbUpdateException.InnerException);
            int cosmosErrorCode = this.cosmosErrorBroker.GetErrorCode(cosmosException);
            ConvertAndThrowMeaningfulException(cosmosErrorCode, cosmosException.Message);
            throw dbUpdateException;
        });

        private CosmosException GetCosmosException(Exception exception) => (CosmosException)exception;
    }
}
