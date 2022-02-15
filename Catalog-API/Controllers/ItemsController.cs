using Catalog_API.Dtos;
using Catalog_API.Models;
using Catalog_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            var items = repository.GetItems().Select(item => item.asDTO());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item.asDTO());
        }

        [HttpPost]
        public ActionResult<ItemDTO> CreateItem(CreateItemDTO itemDTO)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Price = itemDTO.Price,
                CreatedDate = DateTimeOffset.Now
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.asDTO() );
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDTO itemDTO)
        {
            var existingItem = repository.GetItem(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            Item updatedItem = existingItem with
            {
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };
            repository.UpdateItem(updatedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            repository.DeleteItem(id);
            return NoContent();
        }
    }
}
