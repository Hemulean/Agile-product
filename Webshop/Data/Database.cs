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

                //TODO price (random-generator), category, 
                if (item.Category != null & item.Category != "")
                {
                    Random rnd = new Random();

                    double rating;
                    int ratingInt;


                    if (item.Price == "0.0" | item.Price == null)
                    {

                        var priceInt = rnd.Next(1, 35);
                        ratingInt = rnd.Next(1, 5);

                        if (item.Rating == null)
                        {
                            rating = Convert.ToDouble(ratingInt);
                        }
                        else
                        {
                            rating = Convert.ToDouble(item.Rating);
                        }

                        var price = priceInt.ToString();

                        var productRandPrice = new Product
                        {
                            Name = item.Name,
                            Brand = item.Brand,
                            Description = item.Description,
                            Type = item.Type,
                            Price = price,
                            Category = item.Category,
                            Rating = rating,
                            Image = item.Image
                        };

                        _ctx.Products.Add(productRandPrice);


                    }
                    else if (item.Rating == null)
                    {
                        ratingInt = rnd.Next(1, 5);
                        rating = Convert.ToDouble(ratingInt);

                        var product = new Product
                        {
                            Name = item.Name,
                            Brand = item.Brand,
                            Description = item.Description,
                            Type = item.Type,
                            Price = item.Price,
                            Category = item.Category,
                            Rating = rating,
                            Image = item.Image
                        };

                        _ctx.Products.Add(product);
                    }
                    else
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
                }

            }

            await _ctx.SaveChangesAsync();
        }
    }
}
  
