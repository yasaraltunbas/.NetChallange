using BackendCase.DAO;
using BackendCase.DataAccess;
using BackendCase.Repositories;
using BackendCase.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendCase.Controllers
{
    public class SalonController : ControllerBase
    {
        private readonly ISalonRepository _salonRepository;
        private readonly IShowRepository _showRepository;
        private readonly IFilmRepository _filmRepository;


        public SalonController(ISalonRepository salonRepository, IShowRepository showRepository, IFilmRepository filmRepository)
        {
            _salonRepository = salonRepository;
            _showRepository = showRepository;
            _filmRepository = filmRepository;
        }

        [HttpGet("salons")]
        public async Task<IActionResult> GetSalons()
        {
            var salons = new List<SalonDAO>();
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    salons = await _salonRepository.GetSalons(unitOfWork);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(salons);
        }

        [HttpPost("addSalon")]
        public async Task<IActionResult> AddSalon([FromBody] SalonDAO salon)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(true))
                {
                    await _salonRepository.AddSalon(unitOfWork, salon);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }

        [HttpPut("updateSalon")]
        public async Task<IActionResult> UpdateSalon([FromBody] SalonDAO salon)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(true))
                {
                    await _salonRepository.UpdateSalon(unitOfWork, salon);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }

        [HttpDelete("deleteSalon/{salonId}")]
        public async Task<IActionResult> DeleteSalon(int salonId)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(true))
                {
                    await _salonRepository.DeleteSalon(unitOfWork, salonId);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }

        [HttpGet("getSalonsByFilmName/{filmName}")]
        public async Task<IActionResult> GetSalonsByFilmName(string filmName)
        {
            var salons = new List<SalonDAO>();
            try
            {
                using (var unitOfWork = new UnitOfWork(true))
                {
                    var filmId = await _filmRepository.GetFilmIdByName(unitOfWork, filmName);
                    var shows = await _showRepository.GetShowByFilmId(unitOfWork, filmId);
                    foreach (var show in shows)
                    {
                        var salon = await _salonRepository.GetSalonById(unitOfWork, show.SalonID);
                        salons.Add(salon);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(salons);
        }
    }
}
