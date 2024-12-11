using MicroserviceArchitecture.Services.AuthAPI.Models;
using MicroserviceArchitecture.Services.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitecture.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDTO registration);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<bool> AssignRole(string email, string roleName);

        Task<List<ApplicationUser>?> GetAllUsers();
    }
}
