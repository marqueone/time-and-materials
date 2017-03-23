using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marqueone.TimeAndMaterials.Api.Controllers
{

  [Route("_api/[controller]")]
  public class MaterialController : Controller
  {

    ILogger<MaterialController> _logger;

    public MaterialController(ILogger<MaterialController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    [Route("derp")]
    public JsonResult Derp(){
      return Json("derp");
    }

    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        return Json("derp");
      }
      catch (Exception)
      {
        _logger.LogError("Failed to execute GET");
        return BadRequest();
      }
    }
  }
}