using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiero_revisar.Service;

namespace Quiero_revisar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            this._catalogoService = catalogoService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        public async Task< ActionResult> Get()
        {
            return StatusCode(200, await _catalogoService.GetAllCatalogosAsync());
        }
    }
}
