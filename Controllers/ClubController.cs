using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RunGroop.Models;
using RunGroop.Data;

namespace RunGroop.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() //C
        {
            List<Club> clubs =_context.Clubs.ToList(); //M
            return View(clubs); //V
        } 
        
        public IActionResult Detail(int id)
        {
            Club club = _context.Clubs.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
            return View(club);
        }

    }
}