using System;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.DataAccess;
using Marqueone.TimeAndMaterials.Api.DataAccess.Services;
using Marqueone.TimeAndMaterials.Api.Models;
using Marqueone.TimeAndMaterials.Api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marqueone.TimeAndMaterials.Api.Controllers
{

    [Route("_api/[controller]")]
    [Produces("application/json")]
    public class EquipmentController : Controller
    {
        private TamContext _context { get; }
        private ILogger<EquipmentController> _logger;

        private EquipmentService _service { get; set; }

        public EquipmentController(ILogger<EquipmentController> logger,
                                  TamContext context,
                                  EquipmentService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetEquipment()
        {
            try
            {
                return Ok(await _service.GetEquipment());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("by-id/{id}")]
        public async Task<IActionResult> GetEquipmentById(int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500});
            }
        }

        [HttpGet]
        [Route("by-type/{type}")]
        public async Task<IActionResult> GetByRateType(RateTypes type)
        {
            try
            {
                return Ok(await _service.GetByType(type));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]NewServiceViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.Add(name: model.Name,
                                          rateType: model.RateType,
                                          rate: model.Rate);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new Equipment: {model.Name}", Status = 400});
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateServiceViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.Update(id: model.Id,
                                                          name: model.Name,
                                                          rateType: model.RateType,
                                                          rate: model.Rate);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to update Equipment: {model.Name}", Status = 400});
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(id == 0)
                {
                  return StatusCode(400, new { Message = $"Invalid id provided", Status = 400});
                }

                var result = await _service.Delete(id: id);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to delete Equipment with id: {id}", Status = 400});
                }

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500});
            }
        }
    }
}