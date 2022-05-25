using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webshop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Rating { get; set; }

        public double Price { get; set; }

        public double Category { get; set; }


        // TODO Fixa objectreferens till colors, skapa en Color-tabell
       // public List<string> Colors { get; set; }

        public string Image { get; set; }



    }
}
