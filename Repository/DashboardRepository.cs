using Microsoft.EntityFrameworkCore;
using RunGroop.Interfaces;
using RunGroop.Models;
using RunGroop.Data;

namespace RunGroop.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userClubs = _context.Clubs.Where(r => r.AppUser.Id == curUser.ToString());
            return userClubs.ToList();
        }

        public async Task<List<Race>> GetAllUserRaces()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userRaces = _context.Races.Where(r => r.AppUser.Id == curUser.ToString());
            return userRaces.ToList();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<AppUser> GetUserByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {
            _context.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}