using BackendCase.DAO;
using BackendCase.DataAccess;

namespace BackendCase.Repositories.Interfaces
{
    public interface IFilmRepository
    {
        Task<int> AddFilm(UnitOfWork unitOfWork, FilmDAO film);
        Task<int> DeleteFilm(UnitOfWork unitOfWork, int filmId);
        Task<FilmDAO> GetFilmById(UnitOfWork unitOfWork, int filmId);
        Task<List<FilmDAO>> GetFilms(UnitOfWork unitOfWork);
        Task<List<FilmDAO>?> SearchFilmsWithDate(UnitOfWork unitOfWork, int firstYear, int secondYear);
        Task<int> UpdateFilm(UnitOfWork unitOfWork, FilmDAO film);
        Task<int> GetFilmIdByName(UnitOfWork unitOfWork, string filmName);


    }
}