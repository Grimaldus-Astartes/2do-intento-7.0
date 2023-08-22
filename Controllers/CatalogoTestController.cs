using Microsoft.AspNetCore.Mvc;
using Quiero_revisar.Service;

namespace Quiero_revisar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoTestController : ControllerBase
    {
        private readonly ICatalogoService _catalogoService;
        public CatalogoTestController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpGet("GetCatalogs")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCatalogs()
        {
            return StatusCode(200, await _catalogoService.GetAllCatalogosAsync());
        }

    }
}
