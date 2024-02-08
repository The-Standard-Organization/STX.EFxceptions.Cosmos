![STX.EFxceptions.Cosmos](https://raw.githubusercontent.com/The-Standard-Organization/STX.EFxceptions.Cosmos/main/Resources/Images/stx.efCosmos_git_logo.png)

[![.Net](https://github.com/The-Standard-Organization/STX.EFxceptions.Cosmos/actions/workflows/dotnet.yml/badge.svg)](https://github.com/The-Standard-Organization/STX.EFxceptions.Cosmos/actions/workflows/dotnet.yml)
[![The Standard](https://img.shields.io/github/v/release/hassanhabib/The-Standard?filter=v2.10.0&style=default&label=Standard%20Version&color=2ea44f)](https://github.com/hassanhabib/The-Standard)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f)](https://github.com/hassanhabib/The-Standard)
[![The Standard Community](https://img.shields.io/discord/934130100008538142?color=%237289da&label=The%20Standard%20Community&logo=Discord)](https://discord.gg/vdPZ7hS52X)

# STX.EFxceptions.Cosmos

## Introduction
A Standardized .NET library that captures the exceptions thrown by the EntityFramework from a Cosmos DB and converts them into meaningful exceptions...

## STX. EFXceptions.Core Implementation

[STX.EFxceptions.Core](https://github.com/The-Standard-Organization/STX.EFxceptions.Core)

## Standard-Compliance
This library was built according to The Standard. The library follows engineering principles, patterns and tooling as recommended by The Standard.

This library is also a community effort which involved many nights of pair-programming, test-driven development and in-depth exploration research and design discussions.

## Installation 
You can get STX.EFxceptions.Cosmos [Nuget](https://www.nuget.org/packages/STX.EFxceptions.Cosmos) package by typing:
```powershell
Install-Package STX.EFxceptions.Cosmos
```

You can get STX.EFxceptions.Identity.Cosmos [Nuget](https://www.nuget.org/packages/STX.EFxceptions.Identity.Cosmos) package by typing:
```powershell
Install-Package STX.EFxceptions.Identity.Cosmos
```

## Integration
Replace your existing ```DbContext``` class with ```EFxceptionsContext``` (or your `IdentityDbContext` with `EFxceptionIdentityContext`) as follows:

#### Before:
 
```csharp
    public partial class StorageBroker : DbContext, IStorageBroker
    {
        public StorageBroker(DbContextOptions<StorageBroker> options)
            : base(options) => this.Database.Migrate();
    }

```

#### After:
```csharp
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        public StorageBroker(DbContextOptions<StorageBroker> options)
            : base(options) => this.Database.Migrate();
    }

```

## Supported HTTP Status Codes

|Code|Meanings|Exception|
|--- |--- |--- |
|401|Unauthorized: Access denied.|AuthenticationFailedException|
|403|Forbidden: No permission to access.|	AuthorizationFailedException|
|404|Not Found: Resource does not exist.|ResourceNotFoundException|
|408|Request Timeout: Timed out waiting for response.|RequestTimeoutException|
|409|Conflict: Document with same key already exists.|DuplicateKeyException|
|412|Precondition Failed: Expected document condition not met.|PreconditionFailedException|
|413|Payload Too Large: Document exceeds size limit.|PayloadTooLargeException|
|423|Locked: Resource currently unavailable.|ResourceLockedException|
|424|Dependency Failed: Dependency unable to meet requirements.|DependencyFailedException|
|429|Too Many Requests: Rate limit exceeded.|TooManyRequestsException|
|500|Internal Server Error: Server encountered an unexpected condition.|InternalServerException|
|503|Service Unavailable: Server temporarily unable to handle request.|ServiceUnavailableException|

<br >

This library is forever growing as we add more exceptions and codes into it, we appreciate any contributions as there are so many codes we need to cover, so please stay tuned.

## Standard-Promise
The most important fulfillment aspect in a Standard complaint system is aimed towards contributing to people, its evolution, and principles.
An organization that systematically honors an environment of learning, training, and sharing knowledge is an organization that learns from the past, makes calculated risks for the future, 
and brings everyone within it up to speed on the current state of things as honestly, rapidly, and efficiently as possible. 
 
We believe that everyone has the right to privacy, and will never do anything that could violate that right.
We are committed to writing ethical and responsible software, and will always strive to use our skills, coding, and systems for the good.
We believe that these beliefs will help to ensure that our software(s) are safe and secure and that it will never be used to harm or collect personal data for malicious purposes.
 
The Standard Community as a promise to you is in upholding these values.

## Contact

If you have any suggestions, comments or questions, please feel free to contact me on:

[Twitter](https://twitter.com/hassanrezkhabib)

[LinkedIn](https://www.linkedin.com/in/hassanrezkhabib/)

[E-Mail](mailto:hassanhabib@live.com)

### Important Notice
A special thanks to Mr. Hassan Habib and Mr. Christo du Toit for their continuing dedicated contributions.
