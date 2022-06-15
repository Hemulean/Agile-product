
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Webshop.Data;
using Webshop.Models;

namespace CSVConverter;

public class ServiceManagement : IServiceManagement
{
    private IHttpClientFactory _httpClient;
    private  MakeUpDbContext _ctx;
   
    public ServiceManagement(IHttpClientFactory httpClient, MakeUpDbContext ctx)
    {
        _httpClient = httpClient;
        _ctx = ctx;
    }
    public async Task<List<Product>> GetAllDataFromApi()
    {
        // TODO Ta reda på skillnad mellan att skapa en HttpClient objekt eller använda DI IHttpClientFactory (CreateClient())
        List<Product> makeUpList = new List<Product>();


        using (var httpClient = _httpClient.CreateClient())
        {
            using (var response = await httpClient.GetAsync("http://makeup-api.herokuapp.com/api/v1/products.json"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                makeUpList = JsonConvert.DeserializeObject<List<Product>>(apiResponse, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, });
            }

        }
        await SeedFromAPI(makeUpList);

        return makeUpList;
    }

    public  async Task SeedFromAPI(List<Product> responseList)
    {

        await _ctx.Database.EnsureDeletedAsync();
        await _ctx.Database.EnsureCreatedAsync();
      
        foreach (var item in responseList)
        {
            var description = "";
            var ingredients = "";
            string category;
        

           Random rnd = new Random();

           double rating;
           int ratingInt;

            if (item.Category == null | item.Category == "")
            {
                category = "Not available";
            }
            else
            {
                category = item.Category;
            }

            if (item.Description != null & item.Description != "")
            {
                var descriptions = item.Description.Split("Ingredients:");

                if (descriptions.Length == 2)
                {
                    description = descriptions[0];
                    ingredients = descriptions[1];
                }
                else
                {
                    description = descriptions[0];
                    ingredients = "Not available";
                }
                
            }
            else
            {
                description = "Not available";
                ingredients = "Not available";
            }
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
                    Description = description,
                    Ingredients = ingredients,
                    Type = item.Type,
                    Price = price,
                    Category = category,
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
                    Description = description,
                    Ingredients = ingredients,
                    Type = item.Type,
                    Price = item.Price,
                    Category = category,
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
                    Description = description,
                    Ingredients = ingredients,
                    Type = item.Type,
                    Price = item.Price,
                    Category = category,
                    Rating = item.Rating,
                    Image = item.Image
                };

                _ctx.Products.Add(product);
            }

          
        }

        await _ctx.SaveChangesAsync();
    }

   


}

public interface IServiceManagement
{
    Task<List<Product>> GetAllDataFromApi();
}

class Program
{
    static async Task Main(string[] args)
    {
        var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // with AddHttpClient we register the IHttpClientFactory
                services.AddHttpClient();
                // here, we register the dependency injection  
                services.AddScoped<IServiceManagement, ServiceManagement>();
                services.AddScoped<MakeUpDbContext>();
                services.AddDbContext<MakeUpDbContext>(options =>
                    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MakeUpDb"));

               

            }).UseConsoleLifetime();

        var host = builder.Build();

        try
        {
          
            // here we 'get' IServiceManagement
            var myService = host.Services.GetRequiredService<IServiceManagement>();
            host.Services.GetRequiredService<MakeUpDbContext>();
         
            // we run the method GetAllUsers
            await myService.GetAllDataFromApi();


        }
        catch (Exception ex)
        {
            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogError(ex, "An error occurred.");
        }

    }
}