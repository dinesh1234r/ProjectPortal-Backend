using Casbin;
using Microsoft.EntityFrameworkCore;
using ProjectPortal.Data;

namespace ProjectPortal.Services;

public class AuthorizationService
{
    private readonly Enforcer _enforcer;

    public AuthorizationService(AppDbContext context)
    {
        var modelPath = System.IO.Path.Combine(
            AppContext.BaseDirectory,
            "Casbin",
            "model.conf");

        if (!System.IO.File.Exists(modelPath))
        {
            throw new System.IO.FileNotFoundException(
                $"Casbin model file was not found at: {modelPath}",
                modelPath);
        }

        _enforcer = new Enforcer(modelPath);
        LoadPolicies(context);
    }

    private void LoadPolicies(AppDbContext context)
    {
        var rules = context.CasbinRules
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
            else if (rule.PType == "g")
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