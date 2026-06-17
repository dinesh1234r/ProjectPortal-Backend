using Casbin;
using Microsoft.EntityFrameworkCore;
using ProjectPortal.Data;

namespace ProjectPortal.Services;

public class AuthorizationService
{
    private readonly Enforcer _enforcer;

    public AuthorizationService(AppDbContext context)
    {
        _enforcer = new Enforcer("Casbin/model.conf");
        LoadPolicies(context);
    }
    
    private void LoadPolicies(
        AppDbContext context)
    {
        var rules =
            context.CasbinRules
                .AsNoTracking()
                .ToList();

        foreach (var rule in rules)
        {
            if (rule.PType == "p")
            {
                _enforcer.AddPolicy(
                    rule.V0,
                    rule.V1,
                    rule.V2);
            }

            if (rule.PType == "g")
            {
                _enforcer.AddGroupingPolicy(
                    rule.V0,
                    rule.V1);
            }
        }
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