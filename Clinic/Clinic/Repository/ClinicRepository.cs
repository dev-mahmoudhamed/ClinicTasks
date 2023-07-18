using Clinic.Contracts;
using ClinicsManagementsSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repository
{
    public class ClinicRepository : IClinicRepository
    {
        public Task CreateClinic(ClinicEntity clinic)
        {
            throw new NotImplementedException();

        }

        public Task<string> DeleteCkinic(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClinicEntity> GetClinic(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateClinic(int id, ClinicEntity clinic)
        {
            throw new NotImplementedException();
        }

        Task<string> IClinicRepository.CreateClinic(ClinicEntity clinic)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ClinicEntity>> IClinicRepository.GetAllClinics()
        {
            throw new NotImplementedException();
        }
    }
}