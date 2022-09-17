namespace LanguageFeatures.Models
{
    public class ShoppingCart : IProductSelection
    {
        private List<Product> products = new();

        public IEnumerable<Product?> Products { get => products; }

        public ShoppingCart(params Product[] prod)
        {
            products.AddRange(prod);
        }
    }
}
