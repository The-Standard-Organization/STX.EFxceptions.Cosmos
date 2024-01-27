// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Cosmos;
using STX.EFxceptions.Interfaces.Services.EFxceptions;

namespace STX.EFxceptions.Cosmos.Base.Services.Foundations
{
    public interface ICosmosEFxceptionService : IEFxceptionService<CosmosException>
    { }
}
