using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App4.Models;

[assembly: Xamarin.Forms.Dependency(typeof(App4.Services.MockDataStore))]
namespace App4.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items; 

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Firstname = "Firstname1", Lastname="Lastname1", BDay = DateTime.Now.ToLocalTime() },
                new Item { Id = Guid.NewGuid().ToString(), Firstname = "Firstname2", Lastname="Lastname2" },
                new Item { Id = Guid.NewGuid().ToString(), Firstname = "Firstname3", Lastname="Lastname3" },
                new Item { Id = Guid.NewGuid().ToString(), Firstname = "Firstname4", Lastname="Lastname4" },
                new Item { Id = Guid.NewGuid().ToString(), Firstname = "Firstname5", Lastname="Lastname5" },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}