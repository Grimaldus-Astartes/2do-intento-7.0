using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiero_revisar.Service;

namespace Quiero_revisar.Controllers
{
    [Route("api/catalogos")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogosController(ICatalogoService catalogoService)
        {
            this._catalogoService = catalogoService;
        }

        [HttpGet("all")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Get()
        {
            return StatusCode(200, await _catalogoService.GetAllCatalogosAsync());
        }
    }
}
