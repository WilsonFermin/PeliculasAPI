using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class ActorPatchDTO
    {
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
