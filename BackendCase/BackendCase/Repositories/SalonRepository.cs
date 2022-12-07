using BackendCase.DAO;
using BackendCase.DataAccess;
using BackendCase.Repositories.Interfaces;
using LinqToDB;

namespace BackendCase.Repositories
{
    public class SalonRepository : ISalonRepository
    {
        public async Task<List<SalonDAO>> GetSalons(UnitOfWork unitOfWork)
        {
            var salons = new List<SalonDAO>();
            try
            {
                salons = await unitOfWork.Connection.GetTable<SalonDAO>().ToListAsync();

                if (salons == null || !salons.Any())
                {
                    throw new Exception("No salons found");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return salons;
        }

        public async Task<SalonDAO> GetSalonById(UnitOfWork unitOfWork, int salonId)
        {
            var salon = new SalonDAO();
            try
            {
                salon = await unitOfWork.Connection.GetTable<SalonDAO>().Where(x => x.SalonId == salonId).FirstOrDefaultAsync();
                if (salon == null)
                {
                    throw new Exception("No salon found");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return salon;
        }

        public async Task<int> AddSalon(UnitOfWork unitOfWork, SalonDAO salon)
        {
            var result = 0;
            try
            {
                result = await unitOfWork.Connection.InsertAsync(salon);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<int> UpdateSalon(UnitOfWork unitOfWork, SalonDAO salon)
        {
            var result = 0;
            try
            {
                result = await unitOfWork.Connection.UpdateAsync(salon);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<int> GetSalonIdByName(UnitOfWork unitOfWork, string salonName)
        {
            var salon = new SalonDAO();
            try
            {
                salon = await unitOfWork.Connection.GetTable<SalonDAO>().Where(x => x.SalonAd == salonName).FirstOrDefaultAsync();
                if (salon == null)
                {
                    throw new Exception("No salon found");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return salon.SalonId;
        }

        public async Task<int> DeleteSalon(UnitOfWork unitOfWork, int salonId)
        {
            var salon = new SalonDAO();
            var result = 0;
            try
            {
                salon = await unitOfWork.Connection.GetTable<SalonDAO>().Where(x => x.SalonId == salonId).FirstOrDefaultAsync();
                if (salon == null)
                {
                    throw new Exception();
                }
                result = await unitOfWork.Connection.DeleteAsync(salon);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
