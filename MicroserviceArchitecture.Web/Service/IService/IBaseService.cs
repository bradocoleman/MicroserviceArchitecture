using MicroserviceArchitecture.Web.Models;

namespace MicroserviceArchitecture.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDto, bool withBearer = true);
    }
}
