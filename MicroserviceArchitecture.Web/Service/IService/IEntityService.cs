using MicroserviceArchitecture.Web.Models;

namespace MicroserviceArchitecture.Web.Service.IService
{
    public interface IEntityService
    {
        Task<ResponseDTO?> GetEntityAsync(string EntityCode);

        Task<ResponseDTO?> GetAllEntitysAsync();

        Task<ResponseDTO?> GetEntityByIdAsync(int id);

        Task<ResponseDTO?> CreateCopuponAsync(EntityDto EntityDto);

        Task<ResponseDTO> UpdateEntityAysync(EntityDto EntityDto);

        Task<ResponseDTO?> DeleteEntityAsync(int id);

    }
}
