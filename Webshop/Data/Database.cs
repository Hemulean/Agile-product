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


        public async Task CreateAndSeedIfNotExist()
        {
            bool ifNotExist = await _ctx.Database.EnsureCreatedAsync();

            if (ifNotExist)
            {
                await Seed();
            }
        }

        //TODO Ta bort Delete metoden 
        public async Task Delete()
        {
            await _ctx.Database.EnsureDeletedAsync();
        }
        public async Task Seed()
        {

            var responseList = await _apiHandler.GetAllDataFromApi();

            foreach (var item in responseList)
            {
                var rating = " ";

                if (item.Rating.ToString().Length == 2)
                {
                    for (var i = 0; i < item.Rating.ToString().Length; i++)
                    {
                        rating = item.Rating.ToString()[0] + "," + item.Rating.ToString()[1];

                    }
                    var product = new Product
                    {

                        Name = item.Name,
                        Brand = item.Brand,
                        Description = item.Description,
                        Ingredients = item.Ingredients,
                        Type = item.Type,
                        Price = item.Price,
                        Category = item.Category,
                        Rating = Convert.ToDouble(rating),
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
                        Ingredients = item.Ingredients,
                        Type = item.Type,
                        Price = item.Price,
                        Category = item.Category,
                        Rating = item.Rating,
                        Image = item.Image
                    };
                    _ctx.Products.Add(product);
                }

            }

            await _ctx.SaveChangesAsync();
        }
    }
}

