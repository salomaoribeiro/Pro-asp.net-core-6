namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public decimal? Price { get; set; }

        public static Product?[] GetProduct()
        {
            Product kayak = new Product { Name = "Kayak", Price = 275M };
            Product lifejaket = new Product { Name = "Life Jacked", Price = 48.95M };
            Product monalisa = new Product { Name = "Monalisa Picture", Price = 4000.74M };
            Product webcam = new Product { Name = "Web Cam", Price = 349.99M };
            Product bed = new Product { Name = "Bed", Price = 865.23M };

            return new Product?[] { kayak, lifejaket, null, monalisa, webcam, bed };
        }
    }
}
