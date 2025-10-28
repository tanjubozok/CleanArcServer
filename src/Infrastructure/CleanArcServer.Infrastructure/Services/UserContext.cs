using CleanArcServer.Application.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CleanArcServer.Infrastructure.Services;

public sealed class UserContext(HttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid GetUserId()
    {
        var httpContext = httpContextAccessor.HttpContext;
        var claims = httpContext.User.Claims;
        string? userId = (claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value)
            ?? throw new ArgumentNullException("Kullanıcı bilgisi bulunamadı");
        try
        {
            Guid guid = Guid.Parse(userId);
            return guid;
        }
        catch (Exception)
        {
            throw new ArgumentException("Kullanıcı bilgisi geçersiz");
        }
    }
}