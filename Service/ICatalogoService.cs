using Quiero_revisar.Models;

namespace Quiero_revisar.Service
{
    public interface ICatalogoService
    {
        Task<IEnumerable<CatalogoViewModel>> GetAllCatalogosAsync();
    }
}
