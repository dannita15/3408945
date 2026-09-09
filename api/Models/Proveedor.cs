using System.ComponentModel.DataAnnotations;

namespace Tienda.API.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }
    }

}
