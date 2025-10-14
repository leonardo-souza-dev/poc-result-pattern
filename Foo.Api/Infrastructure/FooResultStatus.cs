namespace Foo.Api.Infrastructure;

public abstract class FooResultStatus
{
    public static readonly string EntityCreated = "EntityCreated";
    public static readonly string EntityUpdated = "EntityUpdated";
    public static readonly string EntityDeleted = "EntityDeleted";
    public static readonly string UserAlreadyExists = "UserAlreadyExists";
    public static readonly string EntityNotFound = "EntityNotFound";
    public static readonly string EntityGot = "EntityGot";
    public static readonly string InvalidRequest = "InvalidRequest";
    public static readonly string Unauthorized = "Unauthorized";
    public static readonly string Success = "Success";
    public static readonly string ClientNotFound = "UserNotFound";
}