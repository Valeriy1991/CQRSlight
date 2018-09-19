# CQRSlight

Package|Last version
-|-
CQRSlight|[![NuGet Pre Release](https://img.shields.io/nuget/vpre/CQRSlight.svg)](https://www.nuget.org/packages/CQRSlight/)
CQRSlight.Db|[![NuGet Pre Release](https://img.shields.io/nuget/vpre/CQRSlight.Db.svg)](https://www.nuget.org/packages/CQRSlight.Db/)

Simple abstractions of the CQRS pattern

## Builds

Branch|Build status
-|-
master|[![Build status](https://ci.appveyor.com/api/projects/status/id3t150f2xqr3se6/branch/master?svg=true)](https://ci.appveyor.com/project/Valeriy1991/cqrslight-gvplu/branch/master)
dev|[![Build status](https://ci.appveyor.com/api/projects/status/mue5kwt3l2a9hngk/branch/dev?svg=true)](https://ci.appveyor.com/project/Valeriy1991/cqrslight/branch/dev)


AppVeyor development Nuget project feed: 
https://ci.appveyor.com/nuget/cqrslight-v185sxsmoqs3

## Dependencies

Project|Dependency
-|-
CQRSlight|[Ether.Outcomes](https://github.com/kinetiq/Ether.Outcomes)
CQRSlight.Db|[Ether.Outcomes](https://github.com/kinetiq/Ether.Outcomes), [DbConn.DbExecutor.Abstract](https://github.com/Valeriy1991/DbExecutor)

## Installation

CQRSlight is available as a NuGet packages:

[CQRSlight](https://www.nuget.org/packages/CQRSlight/)

[CQRSlight.Db](https://www.nuget.org/packages/CQRSlight.Db/)

To install it, run the following command in the Package Manager Console:
```
Install-Package CQRSlight
```
```
Install-Package CQRSlight.Db
```

## Description

#### CQRSlight

Contains 3 components:
1. IChecker
2. ICommand
3. IQuery

##### How to use

1. Install the package `CQRSlight` to your project
2. Create your some `Query`:
```csharp
public class BlockedUserQuery : IQuery<List<User>>
{
    public List<User> Get()
    {
        // ... return users that was blocked
    }
}
```
3. Create your some `Command`:
```csharp
public class CreateUserCommand : ICommand<CreateUserCommandContext>
{
    private readonly PasswordHasher _passwordHasher = new PasswordHasher();

    public IOutcome Execute(CreateUserCommandContext commandContext)
    {
        var email = commandContext.Email;
        var password = commandContext.Password;
        
        var passwordHash = _passwordHasher.GetHash(password);

        try
        {
            // ... some logic for create user

            return Outcomes.Success();
        }        
        catch(Exception ex)
        {
            return Outcomes.Failure().FromException(ex);
        }        
    }
}
```
4. For your commands you may needs an `Checker` - some component, that must contains validation logic:
```csharp
public class CreatingUserEmailChecker : IChecker<User>
{
    public IOutcome Check(User creatingUser)
    {
        if(string.isNullOrWhiteSpace(creatingUser.Email))
            return Outcomes.Failure().WithMessage($"Email is required.")
        
        // ... Some other validation logic if you need
        
        return Outcomes.Success();
    }
}
```

---

#### CQRSlight.Db

Contains 3 components:
1. DbQuery
2. DbCommand
3. DbChecker

##### How to use
1. Install the package `CQRSlight.Db` to your project
2. Create your `Query` without any input parameters:
```csharp
public class BlockedUserQuery : DbQuery<List<User>>
{
    public BlockedUserQuery(IDbExecutor dbExecutor) : base(dbExecutor)
    {}

    public override List<User> Get()
    {
        var sql = $@"
select u.*
from dbo.User u
where u.IsBlocked = 1
";
        var blockedUsers = dbExecutor.Query<User>(sql).ToList();
        return blockedUsers;
    }
}
```
Or create your `Query` with some input parameters:
```csharp
public class UserByEmailQuery : DbQuery<string, User>
{
    public UserByEmailQuery(IDbExecutor dbExecutor) : base(dbExecutor)
    {}

    public override User Get(string email)
    {
        var sql = $@"
select u.*
from dbo.User u
where u.Email = '{email}'
";
        var user = dbExecutor.Query<User>(sql).FirstOrDefault();
        return user;
    }
}
```
3. Also you can create some `Command`:
```csharp
public class ResetUserPasswordCommand : DbCommand<int>
{
    public ResetUserPasswordCommand(IDbExecutor dbExecutor) : base(dbExecutor)
    {}

    public override IOutcome Execute(int userId)
    {        
        try
        {
            var userByIdQuery = new UserByIdQuery(DbExecutor);
            var user = userByIdQuery.Get(userId);
            if(user != null)
            {
                // ... Reset user password

                var sql = $@"exec dbo.ResetPassword @userId = {userId}";
                DbExecutor.Execute(sql);

                // ... Send email

                return Outcomes.Success();
            }
            return Outcomes.Failure().WithMessage("User not found");
        }
        catch(Exception ex)
        {
            return Outcomes.Failure().FromException(ex);
        }
    }
} 
```

---

#### What about Checkers?

Checkers (classes that implements `IChecker` interface or abstract class `DbChecker`) 
must be usefull (also as Query) inside of Commands. For example:
```csharp
public class AddNewAccountToUserCommand : DbCommand<Account>
{
    public AddNewAccountToUserCommand(IDbExecutor dbExecutor) : base(dbExecutor)
    {}

    public override IOutcome Execute(Account userAccount)
    {
        var accountChecker = new UserAccountChecker(DbExecutor);
        var checkAccountResult = accountChecker.Check(userAccount);
        var accountIsValid = checkAccountResult.Success();
        if(!accountIsValid)
            return checkAccountResult;
        
        try
        {
            // ... Creating new account for user

            var sql = $@"
insert into dbo.UserAccount ...
";
            DbExecutor.Execute(sql);
            DbExecutor.Commit(); // If DbExecutor was created as transactional

            return Outcomes.Success();
        }
        catch(Exception ex)
        {
            DbExecutor.Rollback();
            return Outcomes.Failure().FromException(ex);
        }
    }
}
```
