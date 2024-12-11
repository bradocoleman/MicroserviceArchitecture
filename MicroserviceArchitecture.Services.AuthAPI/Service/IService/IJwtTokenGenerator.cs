using MicroserviceArchitecture.Services.AuthAPI.Models;

namespace MicroserviceArchitecture.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
