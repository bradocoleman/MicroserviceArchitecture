using AutoMapper;
using MicroserviceArchitecture.Services.EntityAPI.Data;
using MicroserviceArchitecture.Services.EntityAPI.Models;
using MicroserviceArchitecture.Services.EntityAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceArchitecture.Services.EntityAPI.Controllers
{
    [Route("api/Entity")]
    [ApiController]
    public class EntityAPIController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private ResponseDTO _response;
        private IMapper _mapper;

        public EntityAPIController(AppDbContext appDbContext, IMapper mapper)
        {
            _dbContext = appDbContext;
            _response = new ResponseDTO();
            _mapper = mapper;
        }

        #region API Endpoints
        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Entity> objList = _dbContext.Entitys.ToList();
                //Peform mapping
                _response.Result = _mapper.Map<IEnumerable<EntityDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Entity obj = _dbContext.Entitys.First(x => x.EntityId == id);
                //Perform mapping
               
                _response.Result = _mapper.Map<EntityDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDTO GetByCode(string code)
        {
            try
            {
                Entity obj = _dbContext.Entitys.FirstOrDefault(x => x.EntityCode.ToLower() == code.ToLower());
                
                if (obj == null)
                {
                    _response.IsSuccess = false;
                }
                //Perform mapping
                _response.Result = _mapper.Map<EntityDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        //[Route("GetByCode/{code}")]
        public ResponseDTO Post([FromBody] EntityDto EntityDto)
        {
            try
            {
                Entity obj = _mapper.Map<Entity>(EntityDto);
                _dbContext.Entitys.Add(obj);
                //HAVE TO CALL SAVECHANGES IN EF
                _dbContext.SaveChanges();
                _response.Result = _mapper.Map<EntityDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        //[Route("GetByCode/{code}")]
        public ResponseDTO Put ([FromBody] EntityDto EntityDto)
        {
            try
            {
                Entity obj = _mapper.Map<Entity>(EntityDto);
                _dbContext.Entitys.Update(obj);
                _dbContext.SaveChanges();
                _response.Result = _mapper.Map<EntityDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpDelete]
        [Route("{id:int}")]
        public void Delete(int id)
        {
            try
            {
                Entity obj = _dbContext.Entitys.First(x => x.EntityId == id);
                _dbContext.Entitys.Remove(obj);
                _dbContext.SaveChanges();
     
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

        }
        #endregion

    }
}
