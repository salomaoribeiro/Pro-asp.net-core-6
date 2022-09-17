//using LanguageFeatures.Models;
//using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
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


        public ViewResult ExtensionMethod()
        {
            IProductSelection cart = new ShoppingCart(
                  new Product { Name = "Kayak", Price = 275M },
                  new Product { Name = "Life Jacket", Price = 48.95M },
                  new Product { Name = "Soccer Ball", Price = 19.50M },
                  new Product { Name = "Corner Flag", Price = 34.95M }
            );

            return View("Index", cart.Names);
        }


        public ViewResult Lambda()
        {
            return View("Index", Product.GetProduct().Select(p => p?.Name));
        }


        public ViewResult LambdaSimple() => View("Index", Product.GetProduct().Select(p => p?.Name));

        public async Task<ViewResult> IndexTask()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            return View("Index", new string[] { $"Length: {length}" });
        }

        public async Task<ViewResult> IndexTasks()
        {
            List<string> output = new List<string>();
            foreach (long? len in await MyAsyncMethods.GetPagsLengths(output, "apress.com", "microsoft.com", "amazon.com"))
                output.Add($"Page length: {len}");
            return View("Index", output)
            ;
        }


        public async Task<ViewResult> IndexAsyncEnumerable()
        {
            List<string> output = new List<string>();

            await foreach (long? len in MyAsyncMethods.GetPageLengths(output, "apress.com", "microsoft.com", "amazon.com"))
                output.Add($"Page length: {len}");
            return View("Index", output);
        }
    }
}
