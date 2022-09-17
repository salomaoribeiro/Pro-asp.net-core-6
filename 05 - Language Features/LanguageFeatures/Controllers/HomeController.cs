//using LanguageFeatures.Models;
//using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //Product?[] products = Product.GetProduct();
            //Product? product = products[0];

            //string name = $"Product: {products[0]?.Name}, Price: {products[0]?.Price}";

            //return View(new string[] { name });


            Dictionary<string, Product> products = new Dictionary<string, Product> {
              {"Kayak", new Product {Name = "Kayak", Price = 275M}},
              {"Lifejacket", new Product {Name = "Life Jacket", Price = 48.95M}}
            };

            return View("Index", products.Keys);
        }


        public ViewResult Decimal()
        {
            object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };

            decimal total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] is decimal d)
                    total += d;
            }

            return View("Decimal", new string[] { $"Total: {total:C2}" });
        }


        public ViewResult DecimalWhen()
        {
            object[] data = new object[] { 275M, 29.95M, "orange", "apple", 100, 10 };

            decimal total = 0;

            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case decimal decimalValue:
                        total += decimalValue;
                        break;
                    case int intValue when intValue > 50:
                        total += intValue;
                        break;
                }
            }
            return View("DecimalWhen", new string[] { $"Total: {total:C2}" });
        }


        //bool FilterByPrice(Product? p)
        //{
        //    return (p?.Price ?? 0) >= 20;
        //}


        public ViewResult ExtensionMethod()
        {
            IProductSelection cart = new ShoppingCart(
                  new Product { Name = "Kayak", Price = 275M },
                  new Product { Name = "Life Jacket", Price = 48.95M },
                  new Product { Name = "Soccer Ball", Price = 19.50M },
                  new Product { Name = "Corner Flag", Price = 34.95M }
            );


            //Product[] productArray = {
            //      new Product {Name = "Kayak", Price = 275M},
            //      new Product {Name = "Life Jacket", Price = 48.95M},
            //      new Product {Name = "Soccer Ball", Price = 19.50M},
            //      new Product {Name = "Corner Flag", Price = 34.95M}
            //};

            //Func<Product?, bool> namefilter = delegate (Product? prod)
            //{
            //    return prod?.Name?[0] == 'S';
            //}

            //decimal cartTotal = cart.Filter(FilterByPrice).TotalPrices();
            //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
            //decimal nameFilterTotal = productArray.Filter(namefilter).TotalPrices();

            //decimal cartTotal = cart.Filter(p => p?.Price >= 0).TotalPrices();
            //decimal arrayTotal = productArray.Filter(p => (p?.Price ?? 0) > 20).TotalPrices();
            //decimal nameFilterTotal = productArray.Filter(p => p?.Name[0] == 'S').TotalPrices();

            //return View("Index", new string[] { $"Cart total: {cartTotal:C2}", $"Array total: {arrayTotal:C2}", $"By name total: {nameFilterTotal:C2}" });
            //return View("Index", cart.Products?.Select(p => p?.Name));
            return View("Index", cart.Names);
        }

        public ViewResult Lambda()
        {
            return View("Index", Product.GetProduct().Select(p => p?.Name));
        }

        public ViewResult LambdaSimple() => View("Index", Product.GetProduct().Select(p => p?.Name));
    }
}
