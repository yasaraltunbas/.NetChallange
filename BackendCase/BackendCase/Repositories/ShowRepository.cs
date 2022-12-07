using BackendCase.DAO;
using BackendCase.DataAccess;
using BackendCase.Repositories.Interfaces;
using LinqToDB;

namespace BackendCase.Repositories
{
    public class ShowRepository : IShowRepository
    {
        public async Task<List<GosterimDAO>> GetShows(UnitOfWork unitOfWork)
        {
            var shows = new List<GosterimDAO>();
            try
            {
                shows = await unitOfWork.Connection.GetTable<GosterimDAO>().ToListAsync();

                if (shows == null || !shows.Any())
                {
                    throw new Exception("No shows found");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return shows;
        }

        public async Task<List<GosterimDAO>> GetShowBySalonId(UnitOfWork unitOfWork, int salonId)
        {
            var show = new List<GosterimDAO>();
            try
            {
                show = await unitOfWork.Connection.GetTable<GosterimDAO>().Where(x => x.SalonID == salonId).ToListAsync();
                if (show == null)
                {
                    throw new Exception("No show found");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return show;
        }

        public async Task<List<GosterimDAO>> GetShowByFilmId(UnitOfWork unitOfWork, int filmId)
        {
            var show = new List<GosterimDAO>();
            try
            {
                show = await unitOfWork.Connection.GetTable<GosterimDAO>().Where(x => x.FilmID == filmId).ToListAsync();
                if (show == null)
                {
                    throw new Exception("No show found");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return show;
        }


        public async Task<int> AddShow(UnitOfWork unitOfWork, GosterimDAO show)
        {
            var result = 0;
            try
            {
                result = await unitOfWork.Connection.InsertAsync(show);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<int> UpdateShow(UnitOfWork unitOfWork, GosterimDAO show)
        {
            var result = 0;
            try
            {
                result = await unitOfWork.Connection.UpdateAsync(show);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<int> DeleteShow(UnitOfWork unitOfWork, int showId)
        {
            var result = 0;
            try
            {
                result = await unitOfWork.Connection.DeleteAsync(new GosterimDAO { GosterimId = showId });
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }


    }
}
