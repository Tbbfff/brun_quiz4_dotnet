using Microsoft.AspNetCore.Mvc;
using brun_quiz4_dotnet.Models;

namespace brun_quiz4_dotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET /
        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                Products = _db.Products.ToList()
            };
            return View(vm);
        }

        // GET /Home/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
