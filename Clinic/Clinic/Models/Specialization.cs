using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClinicsManagementsSystem.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<ClinicEntity> Clinics { get; set; }
    }
}