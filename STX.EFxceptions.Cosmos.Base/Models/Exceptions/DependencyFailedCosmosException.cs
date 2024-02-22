// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class DependencyFailedCosmosException : Exception
    {
        public DependencyFailedCosmosException(string message) : base(message) { }

        public DependencyFailedCosmosException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
