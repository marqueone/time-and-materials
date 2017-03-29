using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.DataAccess;
using Marqueone.TimeAndMaterials.Api.DataAccess.Services;
using Marqueone.TimeAndMaterials.Api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;

namespace Marqueone.TimeAndMaterials.Api.Controllers
{

    [Route("_api/[controller]")]
    [Produces("application/json")]
    public class AdminController : Controller
    {
        private TamContext _context { get; }
        private ILogger<AdminController> _logger;

        private ServicesService _servicesService { get; set; }
        private TradeService _tradeService { get; set; }
        private CompanyService _companyService { get; set; }

        public AdminController(ILogger<AdminController> logger,
                                  TamContext context,
                                  ServicesService servicesService,
                                  TradeService tradeService,
                                  CompanyService companyService)
        {
            _context = context;
            _logger = logger;
            _servicesService = servicesService;
            _tradeService = tradeService;
            _companyService = companyService;
        }

        #region trade management
        [HttpGet]
        [Route("trades")]
        public async Task<IActionResult> GetTrades()
        {
            try
            {
                return Ok(await _tradeService.GetTrades());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("trade/add")]
        public async Task<IActionResult> AddTrade([FromBody] NewTradeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _tradeService.Add(model.Name, model.PayRate, model.IsActive);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new Trade: {model.Name}", Status = 400 });
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
        [Route("trade/update")]
        public async Task<IActionResult> Update([FromBody] UpdateTradeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _tradeService.Update(model.Id, model.Name, model.PayRate, model.IsActive);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to update Trade: {model.Name}", Status = 400 });
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
        [Route("trade/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return StatusCode(400, new { Message = $"Invalid id provided", Status = 400 });
                }

                var result = await _tradeService.Delete(id: id);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to delete Trade with id: {id}", Status = 400 });
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

        #endregion

        #region companies 
        [HttpGet]
        [Route("companies")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                return Ok(await _companyService.GetCompanies());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("company/add")]
        public async Task<IActionResult> ADdCompany([FromBody] NewCompanyViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _companyService.Add(model.Name);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new Company: {model.Name}", Status = 400 });
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

        /*[HttpPost]
        [Route("trade/update")]
        public async Task<IActionResult> Update([FromBody] UpdateTradeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _tradeService.Update(model.Id, model.Name, model.PayRate, model.IsActive);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to update Trade: {model.Name}", Status = 400 });
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
        [Route("trade/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return StatusCode(400, new { Message = $"Invalid id provided", Status = 400 });
                }

                var result = await _tradeService.Delete(id: id);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to delete Trade with id: {id}", Status = 400 });
                }

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500 });
            }
        }*/
        #endregion
    }
}