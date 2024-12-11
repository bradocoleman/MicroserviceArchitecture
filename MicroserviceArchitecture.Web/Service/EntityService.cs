using MicroserviceArchitecture.Web.Models;
using MicroserviceArchitecture.Web.Service.IService;
using MicroserviceArchitecture.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using static MicroserviceArchitecture.Web.Utility.SD;

namespace MicroserviceArchitecture.Web.Service
{
    public class EntityService : IEntityService
    {
        private readonly IBaseService _baseService;
        public EntityService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO?> CreateCopuponAsync(EntityDto EntityDto)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.POST,
                Data = EntityDto,
                Url = EntityAPIBase + "/api/Entity/"
            });
        }

        public async Task<ResponseDTO?> DeleteEntityAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.DELETE,
                Url = EntityAPIBase + "/api/Entity/" + id
            });
        }

        public async Task<ResponseDTO?> GetAllEntitysAsync()
        {
            var request = new RequestDTO();

            request.ApiType = ApiType.GET;
            request.Url = SD.EntityAPIBase + "/api/Entity";  
            var result = _baseService.SendAsync(request);

            return await result;       
        }

        public async Task<ResponseDTO?> GetEntityAsync(string EntityCode)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.GET,
                Url = EntityAPIBase + "/api/Entity/GetByCode/" + EntityCode
            });
        }

        public async Task<ResponseDTO?> GetEntityByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.GET,
                Url = EntityAPIBase + "/api/Entity/" + id
            });
        }

        public async Task<ResponseDTO> UpdateEntityAysync(EntityDto EntityDto)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiType.PUT,
                Data = EntityDto,
                Url = EntityAPIBase + "/api/Entity"
            });
        }
    }
}
