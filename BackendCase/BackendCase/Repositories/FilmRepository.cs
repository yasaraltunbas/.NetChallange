using BackendCase.DAO;
using BackendCase.DataAccess;
using BackendCase.Repositories.Interfaces;
using LinqToDB;

namespace BackendCase.Repositories
{

    public class FilmRepository : IFilmRepository
    {
        public FilmRepository()
        {
        }

        public async Task<List<FilmDAO>> GetFilms(UnitOfWork unitOfWork)
        {
            var films = new List<FilmDAO>();
            try
            {
                films = await unitOfWork.Connection.GetTable<FilmDAO>().ToListAsync();

                if (films == null || !films.Any())
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return films;
        }

        public async Task<FilmDAO> GetFilmById(UnitOfWork unitOfWork, int filmId)
        {
            var film = new FilmDAO();
            try
            {
                film = await unitOfWork.Connection.GetTable<FilmDAO>().Where(x => x.FilmId == filmId).FirstOrDefaultAsync();
                if (film == null)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return film;
        }

        public async Task<int> AddFilm(UnitOfWork unitOfWork, FilmDAO film)
        {
            var result = 0;
            try
            {
               result= await unitOfWork.Connection.InsertAsync(film);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<int> UpdateFilm(UnitOfWork unitOfWork, FilmDAO film)
        {
            var result = 0;
            try
            {
              result =  await unitOfWork.Connection.UpdateAsync(film);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<int> DeleteFilm(UnitOfWork unitOfWork, int filmId)
        {
            var film = new FilmDAO();
            var result = 0;
            try
            {
                film = await unitOfWork.Connection.GetTable<FilmDAO>().Where(x => x.FilmId == filmId).FirstOrDefaultAsync();
                if (film == null)
                {
                    throw new Exception(); 
                }
              result =  await unitOfWork.Connection.DeleteAsync(film);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<List<FilmDAO>?> SearchFilmsWithDate(UnitOfWork unitOfWork, int firstYear, int secondYear)
        {

            var films = new List<FilmDAO>();
            try
            {
                films = await unitOfWork.Connection.GetTable<FilmDAO>().Where(x => x.FilmYapimYil >= firstYear && x.FilmYapimYil <= secondYear).ToListAsync();
                if (films == null || !films.Any())
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return films;

        }

        public async Task<int> GetFilmIdByName(UnitOfWork unitOfWork, string filmName)
        {
            {
                var film = new FilmDAO();
                var result = 0;
                try
                {
                    film = await unitOfWork.Connection.GetTable<FilmDAO>().Where(x => x.FilmAd == filmName).FirstOrDefaultAsync();
                    if (film == null)
                    {
                        throw new Exception();
                    }
                    result = film.FilmId;
                }
                catch (Exception)
                {
                    throw;
                }
                return result;
            }
        }

    }
}
