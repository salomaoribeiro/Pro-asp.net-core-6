using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers;

public class HomeController : Controller
{
    public ViewResult Index()
    {
        int Hours = DateTime.Now.Hour;
        string viewModel = Hours < 12 ? "Bom dia": "Boa tarde";
        return View("MyView", viewModel);
    }
}
