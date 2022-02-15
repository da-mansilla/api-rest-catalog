using Catalog_API.Dtos;
using Catalog_API.Models;

namespace Catalog_API
{
    public static class Extensions
    {
        public static ItemDTO asDTO(this Item item)
        {
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}
