using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicsManagementsSystem.Models
{
    public class ClinicEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Clinic name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum  length for the Name is 100 characters.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Clinic address is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum  length for the Address is 100 characters.")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Phone number is a required field.")]
        [Phone]
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("specialization")]
        public int SpecializationId { get; set; }
        public Specialization specialization { get; set; }
    }
}
