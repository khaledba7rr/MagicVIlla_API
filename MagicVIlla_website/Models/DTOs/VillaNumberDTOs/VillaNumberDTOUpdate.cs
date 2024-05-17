using System.ComponentModel.DataAnnotations;

namespace MagicVIlla_website.Models.DTOs.VillaNumberDTOs
{
    public class VillaNumberUpdateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string? SpecialDetails { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
