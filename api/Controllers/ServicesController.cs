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
    public class ServicesController : Controller
    {
        private TamContext _context { get; }
        private ILogger<ServicesController> _logger;

        private ServicesService _service { get; set; }

        public ServicesController(ILogger<ServicesController> logger,
                                  TamContext context,
                                  ServicesService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetServices()
        {
            try
            {
                return Ok(await _service.GetServices());
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
        public async Task<IActionResult> GetService(int id)
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
                    return StatusCode(400, new { Message = $"Unable to add new Service: {model.Name}", Status = 400});
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
                    return StatusCode(400, new { Message = $"Unable to update Service: {model.Name}", Status = 400});
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
                    return StatusCode(400, new { Message = $"Unable to delete Service with id: {id}", Status = 400});
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