using System.Collections;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Webshop.Models;


namespace Webshop.Services
{
    public class APIHandler
    {
        private readonly IHttpClientFactory _httpClient;
        public APIHandler(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
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

                   makeUpList = JsonConvert.DeserializeObject<List<Product>>(apiResponse, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore, });
                }

            }

            return makeUpList;
        }

        
    }

    
}
