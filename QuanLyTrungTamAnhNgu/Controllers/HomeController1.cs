using Microsoft.AspNetCore.Mvc;

namespace QuanLyTrungTamAnhNgu.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
