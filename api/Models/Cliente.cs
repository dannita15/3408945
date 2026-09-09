using System.ComponentModel.DataAnnotations;

namespace Tienda.API.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Email { get; set; }
        
        [MaxLength(20)]
        public string? Telefono { get; set; }
    }
}
