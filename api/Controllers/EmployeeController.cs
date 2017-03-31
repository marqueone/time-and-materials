using System;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.DataAccess;
using Marqueone.TimeAndMaterials.Api.DataAccess.Services;
using Marqueone.TimeAndMaterials.Api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marqueone.TimeAndMaterials.Api.Controllers
{

    [Route("_api/[controller]")]
    [Produces("application/json")]
    public class EmployeeController : Controller
    {
        private TamContext _context { get; }
        private ILogger<EmployeeController> _logger;

        private EmployeeService _service { get; set; }

        public EmployeeController(ILogger<EmployeeController> logger,
                                  TamContext context,
                                  EmployeeService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _service.GetEmployees());
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
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500 });
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]NewEmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.Add(firstName: model.FirstName,
                                                lastName: model.LastName,
                                                employeeType: model.Type,
                                                contacts: model.Contacts,
                                                trades: model.Trades);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new Employee: {model.FirstName} {model.LastName}", Status = 400 });
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
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.Update(id: model.Id,
                                                    firstName: model.FirstName,
                                                    lastName: model.LastName,
                                                    employeeType: model.Type,
                                                    contacts: model.Contacts,
                                                    trades: model.Trades);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to update Employee: {model.FirstName} {model.LastName}", Status = 400});
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
        }*/

        [HttpPost]
        [Route("add/contact")]
        public async Task<IActionResult> AddEmployeeContactMethod([FromBody] NewEmployeeContactMethodViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.AddContactMethod(employeeId: model.EmployeeId, contactType: model.Type, value: model.Value, isPrivate: model.IsPrivate);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new Employee Contact Method", Status = 400 });
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
        [Route("update/contact")]
        public async Task<IActionResult> UpdateEmployeeContactMethod([FromBody] UpdateEmployeeContactMethodViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.UpdateEmployeeContact(id: model.Id, contactType: model.Type, value: model.Value, isPrivate: model.IsPrivate);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to update Employee Contact", Status = 400 });
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
        [Route("delete/contact/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(id == 0)
                {
                  return StatusCode(400, new { Message = $"Invalid id provided", Status = 400});
                }

                var result = await _service.DeleteEmployeeContact(id: id);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to delete Employee Contact with id: {id}", Status = 400});
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

        [HttpPost]
        [Route("add/trade")]
        public async Task<IActionResult> AddTrade([FromBody] AddEmployeeTradeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.AddEmployeeTrade(employeeId: model.EmployeeId, tradeId: model.TradeId);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new Trade to Employee", Status = 400 });
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
        [Route("remove/trade")]
        public async Task<IActionResult> RemoveTrade([FromBody] RemoveEmployeeTradeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.RemoveEmployeeTrade(employeeId: model.EmployeeId, tradeId: model.TradeId);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to remove Trade from Employee", Status = 400 });
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
    }
}