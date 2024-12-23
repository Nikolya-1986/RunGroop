using RunGroop.Models;

namespace RunGroop.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();
        Task<Club> GetByIdAsync(int id);
        Task<Club> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Club>> GetClubByCity(string city);
        bool Add(Club clud);
        bool Update(Club club);
        bool Delete(Club club);
        bool Save();
    }
}