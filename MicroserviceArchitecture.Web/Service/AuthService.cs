using MicroserviceArchitecture.Web.Models;
using MicroserviceArchitecture.Web.Service.IService;
using MicroserviceArchitecture.Web.Utility;
using static MicroserviceArchitecture.Web.Utility.SD;

namespace MicroserviceArchitecture.Web.Service
{
    public class AuthService : IAuthService
    {
        readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO?> AssignRoleAsycn(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDTO,
                Url = SD.AuthAPIBase + "/api/auth/AssignRole"
            });
        }

        public async Task<ResponseDTO?> LoginAsycn(LoginRequestDTO loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Data = loginRequestDTO,
                Url = AuthAPIBase + "/api/auth/login"
            }, withBearer: false);
       }

        public async Task<ResponseDTO?> RegisterAsycn(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDTO,
                Url = SD.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}
