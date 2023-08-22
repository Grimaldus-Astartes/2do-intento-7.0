using Microsoft.AspNetCore.Mvc;
using Quiero_revisar.Service;

namespace Quiero_revisar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogosController(ICatalogoService catalogoService)
        {
            this._catalogoService = catalogoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return StatusCode(200, await _catalogoService.GetAllCatalogosAsync());
        }
    }
}
