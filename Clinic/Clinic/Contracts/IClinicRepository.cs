using ClinicsManagementsSystem.Models;

namespace Clinic.Contracts
{
    public interface IClinicRepository
    {
        public Task<IEnumerable<ClinicEntity>> GetAllClinics();
        public Task<ClinicEntity> GetClinic(int id);
        public Task<string> CreateClinic(ClinicEntity clinic);
        public Task<string> UpdateClinic(int id, ClinicEntity clinic);
        public Task<string> DeleteCkinic(int id);


    }
}
