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
    public class ProjectController : Controller
    {
        private TamContext _context { get; }
        private ILogger<ProjectController> _logger;

        private ProjectService _service { get; set; }

        public ProjectController(ILogger<ProjectController> logger,
                                  TamContext context,
                                  ProjectService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                return Ok(await _service.GetProjects());
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
        public async Task<IActionResult> GetProjectsById(int id)
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

        [HttpGet]
        [Route("by-company/{id}")]
        public async Task<IActionResult> GetProjectsByCompanyId(int id)
        {            
            try
            {
                return Ok(await _service.GetByCompany(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500 });
            }
        }

        [HttpGet]
        [Route("by-type/{type}")]
        public async Task<IActionResult> GetByProjectType(ProjectType type)
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
        public async Task<IActionResult> Add([FromBody]NewProjectViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.Add(companyId: model.CompanyId, 
                                                name: model.Name,
                                                projectType: model.ProjectType,
                                                start: model.Start,
                                                end: model.End,
                                                projectedEnd: model.ProjectedEnd);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new Project: {model.Name}", Status = 400 });
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
        public async Task<IActionResult> Update([FromBody] UpdateProjectViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.Update(id: model.Id,
                                                    name: model.Name,
                                                    projectType: model.ProjectType,
                                                    start: model.Start,
                                                    end: model.End,
                                                    projectedEnd: model.ProjectedEnd,
                                                    isComplete: model.IsComplete);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to update Project: {model.Name}", Status = 400 });
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

        #region work orders
        [HttpGet]
        [Route("workorders")]
        public async Task<IActionResult> GetWorkOrders()
        {
            try
            {
                return Ok(await _service.GetWorkOrders());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("workorders/by-id/{id}")]
        public async Task<IActionResult> GetWorkOrdersById(int id)
        {
            try
            {
                return Ok(await _service.GetWorkOrdersById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("workorders/by-project/{id}")]
        public async Task<IActionResult> GetWorkOrdersByProject(int id)
        {
            try
            {
                return Ok(await _service.GetWorkOrderByProjectId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("workorder/add")]
        public async Task<IActionResult> AddWorkOrder([FromBody] NewWorkOrderViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.AddProjectWorkOrder(workOrderId: model.WorkOrderId,
                                                projectId: model.ProjectId);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new WorkOrder: {model.WorkOrderId} to Project: {model.ProjectId}", Status = 400 });
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
        [Route("workorder/add/time")]
        public async Task<IActionResult> AddWorkOrderTime([FromBody] NewTimeEntryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _service.AddWorkOrderTime(id: model.Id,
                employeeId: model.EmployeeId,
                start: model.Start,
                end: model.End,
                isWeekend: model.IsWeekend,
                isHoliday: model.IsHoliday,
                hasOverTime: model.HasOverTime);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new Time Entry for WorkOrder: {model.WorkOrderId}", Status = 400 });
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
        #endregion
    }
}