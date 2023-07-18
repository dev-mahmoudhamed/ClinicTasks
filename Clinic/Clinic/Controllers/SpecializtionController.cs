using Clinic.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : ControllerBase
    {
        private AppDbContext _dbContext;
        public SpecializationsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllSpecializations()
        {
            var specializations = _dbContext.Specializtions.AsNoTracking().ToList();
            return Ok(specializations);
        }

        [HttpGet("{id}")]
        public IActionResult GetSpecialization(int id)
        {
            var specialization = _dbContext.Specializtions.FirstOrDefault(s => s.Id.Equals(id));
            return Ok(specialization);
        }
    }
}
