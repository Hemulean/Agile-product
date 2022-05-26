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
           await _ctx.Database.EnsureCreatedAsync();
        }


        public async Task Seed()
        {
            


        }
    }
}
