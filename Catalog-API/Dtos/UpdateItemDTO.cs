using System.ComponentModel.DataAnnotations;

namespace Catalog_API.Dtos
{
    public record UpdateItemDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}
