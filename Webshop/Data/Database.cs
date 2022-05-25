namespace Webshop.Data
{
    public class Database
    {
        private readonly MakeUpDbContext _ctx;

        public Database(MakeUpDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateDatabse()
        {
           await _ctx.Database.EnsureDeletedAsync();
           await _ctx.Database.EnsureCreatedAsync();
        }
    }
}
