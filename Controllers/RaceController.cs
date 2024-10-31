using Microsoft.AspNetCore.Mvc;
using RunGroop.Models;
using RunGroop.Data;

namespace RunGroop.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Race> rsces = _context.Races.ToList();
            return View(rsces);
        }
    }
}