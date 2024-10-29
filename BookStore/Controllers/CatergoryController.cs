using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CatergoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
