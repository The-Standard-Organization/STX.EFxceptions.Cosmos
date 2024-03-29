﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.Cosmos.Base.Models.Exceptions
{
    public class DuplicateKeyCosmosException : DbUpdateException
    {
        public DuplicateKeyCosmosException(string message) : base(message) { }

        public DuplicateKeyCosmosException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
