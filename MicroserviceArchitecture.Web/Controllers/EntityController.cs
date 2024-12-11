using MicroserviceArchitecture.Web.Models;
using MicroserviceArchitecture.Web.Service;
using MicroserviceArchitecture.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroserviceArchitecture.Web.Controllers
{
    public class EntityController : Controller
    {
        private readonly IEntityService _EntityService;
        public EntityController(IEntityService EntityService)
        {
            _EntityService = EntityService;
        }
        public async Task<IActionResult> EntityIndex()
        {
            List<EntityDto>? list = new();

            ResponseDTO? response = await _EntityService.GetAllEntitysAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EntityDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        public async Task<IActionResult> EntityCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EntityCreate(EntityDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDTO? response = await _EntityService.CreateCopuponAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Entity created successfully";
                    return RedirectToAction(nameof(EntityIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> EntityDelete(int EntityId)
        {
            ResponseDTO? response = await _EntityService.GetEntityByIdAsync(EntityId);

            if (response != null && response.IsSuccess)
            {
                EntityDto? model = JsonConvert.DeserializeObject<EntityDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EntityDelete(EntityDto EntityDto)
        {
            ResponseDTO? response = await _EntityService.DeleteEntityAsync(EntityDto.EntityId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Entity deleted successfully";
                return RedirectToAction(nameof(EntityIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(EntityDto);
        }
    }
    }
