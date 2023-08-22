using System.ComponentModel.DataAnnotations;

namespace Quiero_revisar.Data_Entities
{
    public class CatalogoEntity
    {
        [Key]
        public int Id { get; set; }
        public string descripcion { get; set; }
    }
}
