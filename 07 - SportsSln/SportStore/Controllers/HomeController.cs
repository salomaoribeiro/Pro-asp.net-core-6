using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class HomeController: Controller
    {
        private readonly IStoreRepository _repository;
        public int PageSize = 4;

        public HomeController(IStoreRepository repository)
        {
            this._repository = repository;
        }
        public IActionResult Index(int productPage = 1) 
            => View(_repository.Products
                .OrderBy(p => p.ProductId) 
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize)
                );
    }
}
