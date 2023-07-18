using Clinic.Data;
using ClinicsManagementsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicsManagementsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private AppDbContext _dbContext;
        public ClinicsController(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllClinics()
        {
            ///  هنا مفيش  AsNoTracking() بسس ال SoftDelete

            var clinics = _dbContext.Clinics
                .Where(c => c.IsDeleted.Equals(false))
                .Include(c => c.specialization)
                .OrderBy(c => c.Name).ToList();

            return Ok(clinics);
        }

        [HttpGet("{clinicId}")]
        public IActionResult GetClinicById(int clinicId)
        {
            var clinic = _dbContext.Clinics
                .Include(c => c.specialization)
                .FirstOrDefault(c => c.Id.Equals(clinicId));

            if (clinic is null || clinic.IsDeleted == true)
            {
                return NotFound();
            }

            return Ok(clinic);
        }

        [HttpPost]
        public void AddClinic(ClinicEntity clinic)
        {
            _dbContext.Clinics.Add(clinic);
            _dbContext.SaveChanges();

        }

        [HttpDelete("{clinicId}")]
        public void DeleteClinic(int clinicId)
        {
            var clinic = _dbContext.Clinics.FirstOrDefault(c => c.Id.Equals(clinicId));
            clinic.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        [HttpPut("{clinicId}")]
        public IActionResult UpdateClinic(int clinicId, ClinicEntity clinic)
        {
            var existClinic = _dbContext.Clinics.FirstOrDefault(c => c.Id.Equals(clinicId));
            if (existClinic is null || existClinic.IsDeleted == true)
            {
                return NotFound();
            }

            existClinic.Name = clinic.Name;
            existClinic.SpecializationId = clinic.SpecializationId;
            existClinic.PhoneNumber = clinic.PhoneNumber;
            existClinic.Address = clinic.Address;

            _dbContext.SaveChanges();
            return Ok(existClinic);
        }
    }
}
