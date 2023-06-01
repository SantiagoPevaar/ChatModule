using Volo.Abp.Reflection;

namespace Test3.IdentityService.Permissions;

public class IdentityServicePermissions
{
    public const string GroupName = "IdentityService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(IdentityServicePermissions));
    }
}
