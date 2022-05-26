using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Webshop.Models;
using Webshop.Services;

namespace Webshop.Data
{
    public class Database
    {
        private readonly MakeUpDbContext _ctx;
        private readonly APIHandler _apiHandler;

        public Database(MakeUpDbContext ctx, APIHandler apiHandler)
        {
            _ctx = ctx;
            _apiHandler = apiHandler;
        }

        public async Task CreateDatabse()
        {
           await _ctx.Database.EnsureDeletedAsync();
        
        }

        public async Task CreateAndSeedIfNotExist()
        {
            bool ifNotExist = await _ctx.Database.EnsureCreatedAsync();

            if (ifNotExist)
            {
                await Seed();
            }
        }

        public async Task Seed()
        {
            var responseList = await _apiHandler.GetAllDataFromApi();

            foreach (var item in responseList)
            {
                var product = new Product
                {
                    Name = item.Name,
                    Brand = item.Brand,
                    Description = item.Description,
                    Type = item.Type,
                    Price = item.Price,
                    Category = item.Category,
                    Rating = item.Rating,
                    Image = item.Image
                };

                _ctx.Products.Add(product);
                
            }

            await _ctx.SaveChangesAsync();
        }
    }
}
