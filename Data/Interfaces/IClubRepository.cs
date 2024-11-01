using RunGroop.Models;

namespace RunGroop.Data.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();
        Task<Club> GetByIdAsync(int id);
        Task<IEnumerable<Club>> GetClubByCity(string city);
        bool Add(Club clud);
        bool Update(Club club);
        bool Delete(Club club);
        bool Save();
    }
}