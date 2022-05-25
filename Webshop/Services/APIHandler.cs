using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Webshop.Services
{
    public class APIHandler
    {

        public async Task<List<string>> GetAllDataFromApi()
        {

            List<string> makeUpList = new List<string>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://makeup-api.herokuapp.com/api/v1/products.json"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    makeUpList = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                }

                return makeUpList;

            }

        }
    }
}
