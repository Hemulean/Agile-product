using Microsoft.EntityFrameworkCore;
using Webshop.Data;
using Webshop.Models;

namespace Webshop.Services
{
    public class ProductHandler
    {
        private readonly MakeUpDbContext _ctx;
        public ProductHandler(MakeUpDbContext ctx)
        {
            _ctx = ctx;
        }


        public async Task<List<Product>> GetMostPopularProducts(int limit)
        {
            var productRatingList = await _ctx.Products.Where(r => r.Rating == 5.0).ToListAsync();
            var newList = new List<Product>();

            foreach (var item in productRatingList)
            {
                
                while (newList.Count< limit)
                {
                    newList.Add(item);
                }
            }

            return newList;
        }
    }
}
