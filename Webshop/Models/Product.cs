using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Webshop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("product_type")]
        public string Type { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }


        // TODO Fixa objectreferens till colors, skapa en Color-tabell
        // public List<string> Colors { get; set; }

        [JsonProperty("image_link")]
        public string Image { get; set; }

        [JsonProperty("product_link")]
        public string Product_link { get; set; }

    }
}
