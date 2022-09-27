using SimpleApp.Controllers;
using SimpleApp.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;


namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionModelIsComplete()
        {
            //Arrange
            var controller = new HomeController();

            Product[] products = new Product[]
            {
              new Product {Name = "Kayak", Price = 275M},
              new Product { Name = "Life Jacket", Price = 48.95M}
            };

            //ACT
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(products, model, Comparer.Get<Product>(
                  (p1, p2) => p1?.Name == p2?.Name && p1?.Price == p2?.Price)
                );
        }
    }
}
