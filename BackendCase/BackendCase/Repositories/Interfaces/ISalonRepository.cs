using BackendCase.DAO;
using BackendCase.DataAccess;

namespace BackendCase.Repositories.Interfaces
{
    public interface ISalonRepository
    {
        Task<int> AddSalon(UnitOfWork unitOfWork, SalonDAO salon);
        Task<SalonDAO> GetSalonById(UnitOfWork unitOfWork, int salonId);
        Task<List<SalonDAO>> GetSalons(UnitOfWork unitOfWork);
        Task<int> UpdateSalon(UnitOfWork unitOfWork, SalonDAO salon);
        Task<int> GetSalonIdByName(UnitOfWork unitOfWork, string salonName);
        Task<int> DeleteSalon(UnitOfWork unitOfWork, int salonId);
    }
}