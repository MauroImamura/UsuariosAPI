using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UsuariosApi.Authorization;

namespace UsuariosAPI.Authorization;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var dataNascimentoClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);
        if (dataNascimentoClaim is null) return Task.CompletedTask;
        var dataNascimento = Convert.ToDateTime(dataNascimentoClaim.Value);
        if (DateTime.UtcNow.AddYears(-requirement.Idade) >= dataNascimento) context.Succeed(requirement);
        return Task.CompletedTask;
    }
}
