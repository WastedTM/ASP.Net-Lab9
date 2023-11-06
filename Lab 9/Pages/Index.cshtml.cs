using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab_9.Pages;

public class Product : PageModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public List<Product> Products { get; set; }

    public void OnGet()
    {
        Products = new List<Product>
        {
            new Product { ID = 1, Name = "Pizza", Price = 10.99 },
            new Product { ID = 2, Name = "Sushi", Price = 30.50 },
            new Product { ID = 3, Name = "Ice cream", Price = 3 }
        };
    }
}