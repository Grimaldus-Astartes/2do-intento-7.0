using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quiero_revisar.Data_Context;
using Quiero_revisar.Models;

namespace Quiero_revisar.Service.Implementation
{
    public class CatalogoService : ICatalogoService
    {
        private readonly TiendaComics _dbContextService;
        private readonly IMapper _mapperService;

        public CatalogoService(TiendaComics dbContextService, IMapper mapperService)
        {
            this._dbContextService = dbContextService;
            this._mapperService = mapperService;
        }

        public async Task<IEnumerable<CatalogoViewModel>> GetAllCatalogosAsync()
        {
            return _mapperService
                .Map<IEnumerable<CatalogoViewModel>>(await _dbContextService.Catalogos.ToListAsync());
        }

    }
}
