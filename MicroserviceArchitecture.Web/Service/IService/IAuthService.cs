using MicroserviceArchitecture.Web.Models;

namespace MicroserviceArchitecture.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO?> LoginAsycn(LoginRequestDTO loginRequestDTO);
        Task<ResponseDTO?> RegisterAsycn(RegistrationRequestDTO registrationRequestDTO);
        Task<ResponseDTO?> AssignRoleAsycn(RegistrationRequestDTO registrationRequestDTO);

    }
}
