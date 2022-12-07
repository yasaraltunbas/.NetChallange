using BackendCase.DAO;
using BackendCase.DataAccess;
using BackendCase.Repositories;
using BackendCase.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCase.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IShowRepository _showRepository;
        private readonly ISalonRepository _salonRepository;

        public FilmController(IFilmRepository filmRepository, ISalonRepository salonRepository,IShowRepository showRepository)
        {
            _filmRepository = filmRepository;
            _showRepository = showRepository;
            _salonRepository = salonRepository;
        }

        [HttpGet("films")]
        public async Task<IActionResult> GetFilms()
        {
            var films = new List<FilmDAO>();
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    films = await _filmRepository.GetFilms(unitOfWork);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(films);
        }

        [HttpPost("addFilm")]
        public async Task<IActionResult> AddFilm([FromBody] FilmDAO film)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(true))
                {
                    await _filmRepository.AddFilm(unitOfWork, film);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }

        [HttpPut("updateFilm")]
        public async Task<IActionResult> UpdateFilm([FromBody] FilmDAO film)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(true))
                {
                    await _filmRepository.UpdateFilm(unitOfWork, film);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }

        [HttpDelete("deleteFilm/{filmId}")]
        public async Task<IActionResult> DeleteFilm(int filmId)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(true))
                {
                    await _filmRepository.DeleteFilm(unitOfWork, filmId);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }

        [HttpGet("searchFilmBetweenYears")]
        public async Task<IActionResult> SearchBetweenDates(int firstYear, int secondYear)
        {
            var films = new List<FilmDAO>();
            try
            {
                using (var unitOfWork = new UnitOfWork(true))
                {
                   films= await _filmRepository.SearchFilmsWithDate(unitOfWork, firstYear, secondYear);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(films);
        }

        [HttpGet("getFilmsBySalonName/{salonName}")]
        public async Task<IActionResult> GetFilmsBySalonName(string salonName)
        {
            var films = new List<FilmDAO>();
            try
            {
                using (var unitOfWork = new UnitOfWork(true))
                {
                    var salonId = await _salonRepository.GetSalonIdByName(unitOfWork, salonName);
                    var shows = await _showRepository.GetShowBySalonId(unitOfWork, salonId);
                    foreach (var show in shows)
                    {
                        var film = await _filmRepository.GetFilmById(unitOfWork, show.FilmID);
                        films.Add(film);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(films);
        }

    }
}
