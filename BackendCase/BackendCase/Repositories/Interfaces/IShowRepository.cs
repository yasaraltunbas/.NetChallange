using BackendCase.DAO;
using BackendCase.DataAccess;

namespace BackendCase.Repositories.Interfaces
{
    public interface IShowRepository
    {
        Task<int> AddShow(UnitOfWork unitOfWork, GosterimDAO show);
        Task<int> DeleteShow(UnitOfWork unitOfWork, int showId);
        Task<List<GosterimDAO>> GetShowBySalonId(UnitOfWork unitOfWork, int showId);
        Task<List<GosterimDAO>> GetShows(UnitOfWork unitOfWork);
        Task<int> UpdateShow(UnitOfWork unitOfWork, GosterimDAO show);

        Task<List<GosterimDAO>> GetShowByFilmId(UnitOfWork unitOfWork, int filmId);
    }
}