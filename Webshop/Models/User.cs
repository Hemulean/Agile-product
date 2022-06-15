using Microsoft.AspNetCore.Identity;

namespace Webshop.Models
{
    public class User : IdentityUser
    {
        public IList<Product>? Products { get; set; }
    }
}
