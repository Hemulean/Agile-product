using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Webshop.Models
{
    public class Product
    {
        [Key]
        [CsvHelper.Configuration.Attributes.Index(0)]
      
        public int Id { get; set; }

        [CsvHelper.Configuration.Attributes.Index(1)]
        [JsonProperty("name")]
        public string? Name { get; set; }

        [CsvHelper.Configuration.Attributes.Index(2)]
        [JsonProperty("brand")]
        public string? Brand { get; set; }

        [CsvHelper.Configuration.Attributes.Index(3)]
        [JsonProperty("description")]
        public string? Description { get; set; }

        [CsvHelper.Configuration.Attributes.Index(4)]
        [JsonProperty("product_type")]
        public string? Type { get; set; }

        [CsvHelper.Configuration.Attributes.Index(5)]
        [JsonProperty("rating")]
        public double? Rating { get; set; }

        [CsvHelper.Configuration.Attributes.Index(6)]
        [JsonProperty("price")]
        public string? Price { get; set; }

        [CsvHelper.Configuration.Attributes.Index(7)]
        [JsonProperty("category")]
        public string? Category { get; set; }

        [CsvHelper.Configuration.Attributes.Index(8)]
        public string? Ingredients { get; set; }


        // TODO Fixa objectreferens till colors, skapa en Color-tabell
        // public List<string> Colors { get; set; }

        [CsvHelper.Configuration.Attributes.Index(9)]
        [JsonProperty("image_link")]
        public string? Image { get; set; }

        [CsvHelper.Configuration.Attributes.Index(10)]
        public User? User { get; set; }

    }
}
