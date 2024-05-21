using Microsoft.EntityFrameworkCore;
using PatientInfoPortal.Api.Data;
using PatientInfoPortal.Api.Models;
using PatientInfoPortal.Shared.Dtos;

namespace PatientInfoPortal.Api.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientInfoPortalContext _context;

        public PatientRepository(PatientInfoPortalContext context)
        {
            _context = context;
        }

        public async Task AddPatient(PatientCreateDto patientCreateDto)
        {
            var patient = new PatientsInformation
            {
                Name = patientCreateDto.PatientName,
                DiseaseId = patientCreateDto.DiseaseId,
                Epilepsy = patientCreateDto.Epilepsy,
                AllergiesDetails = new List<AllergiesDetail>(),
                NcdDetails = new List<NcdDetail>()
            };

            foreach (var allergyId in patientCreateDto.AllergyIds)
            {
                var allergy = new AllergiesDetail
                {
                    AllergiesId = allergyId
                };

                patient.AllergiesDetails.Add(allergy);
            }

            foreach (var ncdId in patientCreateDto.NcdIds)
            {
                var ncd = new NcdDetail
                {
                    Ncdid = ncdId
                };

                patient.NcdDetails.Add(ncd);
            }

            await _context.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatient(int id)
        {
            var patient = await _context.PatientsInformations.FindAsync(id);

            if (patient != null)
            {
                _context.PatientsInformations.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PatientsInformationDto> GetPatientById(int id)
        {
            var patients = await _context.PatientsInformations.Where(x => x.Id == id).Select(x =>
                new PatientsInformationDto
                {
                    ID = x.Id,
                    Name = x.Name,
                    Epilepsy = x.Epilepsy,
                    Disease = new DiseaseInformationDto { Id = x.Disease.Id, Name = x.Disease.Name },
                    NCDs = x.NcdDetails.Select(nd =>
                        new NcdDto
                        {
                            Id = nd.Ncd.Id,
                            Name = nd.Ncd.Name
                        }
                    ).ToList(),
                    Allergies = x.AllergiesDetails.Select(ad =>
                        new AllergyDto
                        {
                            Id = ad.Allergies.Id,
                            Name = ad.Allergies.Name
                        }
                    ).ToList()
                }
            ).FirstOrDefaultAsync();

            return patients;
        }

        public async Task<List<PatientsInformationDto>> GetPatients()
        {
            var patients = await _context.PatientsInformations.Select(x =>
                new PatientsInformationDto
                {
                    ID = x.Id,
                    Name = x.Name,
                    Epilepsy = x.Epilepsy,
                    Disease = new DiseaseInformationDto { Id = x.Disease.Id, Name = x.Disease.Name },
                    NCDs = x.NcdDetails.Select(nd =>
                        new NcdDto
                        {
                            Id = nd.Ncd.Id,
                            Name = nd.Ncd.Name
                        }
                    ).ToList(),
                    Allergies = x.AllergiesDetails.Select(ad =>
                        new AllergyDto
                        {
                            Id = ad.Allergies.Id,
                            Name = ad.Allergies.Name
                        }
                    ).ToList()
                }
            ).ToListAsync();

            return patients;
        }

        public async Task UpdatePatient(PatientUpdateDto patientUpdateDto)
        {
            var patient = await _context.PatientsInformations.Include(x => x.AllergiesDetails).Include(x => x.NcdDetails).Where(x => x.Id == patientUpdateDto.PatientId).FirstOrDefaultAsync();

            if(patient == null)
            {
                throw new ArgumentException("Patient Not Found");
            }

            patient.Name = patientUpdateDto.PatientName;
            patient.Epilepsy = patientUpdateDto.Epilepsy;
            patient.DiseaseId = patientUpdateDto.DiseaseId;

            _context.RemoveRange(patient.AllergiesDetails);
            _context.RemoveRange(patient.NcdDetails);

            patient.AllergiesDetails.Clear();
            patient.NcdDetails.Clear();

            foreach (var allergyId in patientUpdateDto.AllergyIds)
            {
                var allergy = new AllergiesDetail
                {
                    AllergiesId = allergyId
                };

                patient.AllergiesDetails.Add(allergy);
            }

            foreach (var ncdId in patientUpdateDto.NcdIds)
            {
                var ncd = new NcdDetail
                {
                    Ncdid = ncdId
                };

                patient.NcdDetails.Add(ncd);
            }

            await _context.SaveChangesAsync();
        }

    }
}
