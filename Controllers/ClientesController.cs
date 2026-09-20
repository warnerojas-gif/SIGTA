using Microsoft.AspNetCore.Mvc;

namespace SIGTA.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}