using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Webshop.Data;
using Webshop.Models;


namespace Webshop.Services
{
    public class APIHandler
    {

        public async Task<List<Product>> GetAllDataFromApi()
        {
            {
                // TODO Ta reda på skillnad mellan att skapa en HttpClient objekt eller använda DI IHttpClientFactory (CreateClient())
                List<Product> makeUpList = new List<Product>();

                

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    MissingFieldFound = null
                };

                using (var reader = new StreamReader("DataBackUpMakeUpApi.csv"))

                using (var csv = new CsvReader(reader, config))
                {
                   await csv.ReadAsync();
                    csv.ReadHeader();

                    while (await csv.ReadAsync())
                    {
                        var record = csv.GetRecord<Product>();
                        
                        makeUpList.Add(record);
                    }
                }

                return  makeUpList;
            }


        }

    }
}
