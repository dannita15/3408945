using System.ComponentModel.DataAnnotations;

namespace Tienda.API.Models
{
    public class MetodoDePago
    {
        [Key]
        public int IdMetodoDePago{ get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nombre { get; set; }

    }
}
