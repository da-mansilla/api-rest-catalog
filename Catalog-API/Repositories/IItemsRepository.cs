using Catalog_API.Models;
using System;
using System.Collections.Generic;

namespace Catalog_API.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);

    }
}
