using System.Collections.Generic;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.DataAccess;
using Marqueone.TimeAndMaterials.Api.DataAccess.Services;
using Marqueone.TimeAndMaterials.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Marqueone.TimeAndMaterials.Api.Controllers
{

    [Route("_api/[controller]")]
    public class MaterialController : Controller
    {
        private TamContext _context { get; set; }
        private ILogger<MaterialController> _logger;

        private MaterialService _materials { get; set; }

        public MaterialController(ILogger<MaterialController> logger,
                                  TamContext context,
                                  MaterialService service)
        {
            _context = context;
            _logger = logger;
            _materials = service;
        }

        [HttpGet]
        [Route("materials")]
        public async Task<IList<Material>> GetMaterials()
        {
            return await _materials.GetMaterials();
        }
    }
}