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
    public class MaterialsController : Controller
    {
        private TamContext _context { get; }
        private ILogger<MaterialsController> _logger;

        private MaterialService _materials { get; set; }

        public MaterialsController(ILogger<MaterialsController> logger,
                                  TamContext context,
                                  MaterialService materialService)
        {
            _context = context;
            _logger = logger;
            _materials = materialService;
        }

        [HttpGet]
        [Route("materials")]
        public async Task<IActionResult> GetMaterials()
        {
            try
            {
                return Ok(await _materials.GetMaterials());
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
        public async Task<IActionResult> GetMaterial(int id)
        {
            try
            {
                return Ok(await _materials.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("by-type/{type}")]
        public async Task<IActionResult> GetByUnitType(UnitType type)
        {
            try
            {
                return Ok(await _materials.GetByType(type));
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
        public async Task<IActionResult> Add([FromBody]NewMaterialViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                await _materials.AddMaterial(name: model.Name,
                                      cost: model.Cost,
                                      unitOfMeasure: model.UnitOfMeasure);

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
        public async Task<IActionResult> Update([FromBody] UpdateMaterialViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _materials.UpdateMaterial(id: model.Id,
                                                             name: model.Name,
                                                             cost: model.Cost,
                                                             unitOfMeasure: model.UnitOfMeasure);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to update Material: {model.Name}", Status = 400 });
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
                if (id == 0)
                {
                    return StatusCode(400, new { Message = $"Invalid id provided", Status = 400 });
                }

                var result = await _materials.DeleteMaterial(id: id);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to delete Material with id: {id}", Status = 400 });
                }

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500 });
            }
        }

        [HttpGet]
        [Route("units")]
        public async Task<IActionResult> GetUnitsOfMeasure()
        {
            try
            {
                return Ok(await _materials.GetUnitsOfMeasure());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("units/by-id/{id}")]
        public async Task<IActionResult> GetUnitById(int id)
        {
            try
            {
                return Ok(await _materials.GetUnitOfMeasureById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("units/by-type/{type}")]
        public async Task<IActionResult> GetUnitsByType(UnitType type)
        {
            try
            {
                return Ok(await _materials.GetUnitsOfMeasureByType(type));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("units/add")]
        public async Task<IActionResult> AddUnitsOfMeasure([FromBody]NewUnitOfMeasureViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                await _materials.AddUnitOfMeasure(name: model.Name,
                                                 value: model.Value,
                                                 unitType: model.UnitType);

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
        [Route("units/update")]
        public async Task<IActionResult> UpdateUnitOfMeasure([FromBody] UpdateUnitOfMeasureViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _materials.UpdateUnitOfMeasure(id: model.Id,
                                                                  name: model.Name,
                                                                  value: model.Value,
                                                                  unitType: model.UnitType);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to update UnitOfMeasure: {model.Name}", Status = 400 });
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
        [Route("units/delete/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteUnitOfMeasure(int id)
        {
            try
            {
                if (id == 0)
                {
                    return StatusCode(400, new { Message = $"Invalid id provided", Status = 400 });
                }

                var result = await _materials.DeleteUnitOfMeasure(id: id);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to delete UnitOfMeasure with id: {id}", Status = 400 });
                }

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500 });
            }
        }

    }
}