using Casbin;

namespace ProjectPortal.Services;

public class AuthorizationService
{
    private readonly Enforcer _enforcer;

    public AuthorizationService()
    {
        _enforcer = new Enforcer(
            "Casbin/model.conf",
            "Casbin/policy.csv");
    }

    public bool IsAuthorized(
        string role,
        string resource,
        string action)
    {
        return _enforcer.Enforce(
            role,
            resource,
            action);
    }
    
}