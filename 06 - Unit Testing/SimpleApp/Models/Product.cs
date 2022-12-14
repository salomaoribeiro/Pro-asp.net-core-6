namespace SimpleApp.Models
{
    public class Product
    {
        public string Name { get; set; } = String.Empty;
        public decimal? Price { get; set; }

        // public static Product[] GetProducts()
        // {
        //     Product kayak = new Product { Name = "Kayak", Price = 275M };
        //     Product lifeJacket = new Product { Name = "Life Jacket", Price = 48.95M };

        //     return new Product[] { kayak, lifeJacket };
        // }
    }

    public class ProductDataSource : IDataSource
    {
        public IEnumerable<Product> Products =>
          new Product[] {
            new Product {Name = "Kayak", Price = 275M},
            new Product { Name = "Life Jack", Price = 48.95M}
          };
    }
}
