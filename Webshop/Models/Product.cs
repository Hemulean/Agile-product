using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;


namespace Webshop.Models
{
    public class Product
    {
        [Key]
        [CsvHelper.Configuration.Attributes.Index(0)]
        public int Id { get; set; }

        [CsvHelper.Configuration.Attributes.Index(1)]
        public string? Name { get; set; }

        [CsvHelper.Configuration.Attributes.Index(2)]
        public string? Brand { get; set; }

        [CsvHelper.Configuration.Attributes.Index(3)]
        public string? Description { get; set; }

        [CsvHelper.Configuration.Attributes.Index(4)]
        public string? Type { get; set; }

        [CsvHelper.Configuration.Attributes.Index(5)]
        public double? Rating { get; set; }

        [CsvHelper.Configuration.Attributes.Index(6)]
        public string? Price { get; set; }

        [CsvHelper.Configuration.Attributes.Index(7)]
        public string? Category { get; set; }

        [CsvHelper.Configuration.Attributes.Index(8)]
        public string? Ingredients { get; set; }


        // TODO Fixa objectreferens till colors, skapa en Color-tabell
        // public List<string> Colors { get; set; }

        [CsvHelper.Configuration.Attributes.Index(9)]
        public string? Image { get; set; }

       
        public User? User { get; set; }

    }
}
