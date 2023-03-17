using System.ComponentModel.DataAnnotations;

namespace IntroducciónAEDCore.DTOs
{
    public class GeneroCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
    }
}
