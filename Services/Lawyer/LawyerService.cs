using Microsoft.EntityFrameworkCore;
using MizanGraduationProject.Data;
using MizanGraduationProject.Data.DTOs;
using MizanGraduationProject.Data.Models;
using MizanGraduationProject.Data.Models.ResponseSchema;
using MizanGraduationProject.Repositories.Lawyer;
using MizanGraduationProject.Repositories.Specialization;

namespace MizanGraduationProject.Services.Lawyer
{
    public class LawyerService : ILawyerService
    {
        private readonly ILawyerRepository _lawyerRepository;
        private readonly ISpecializationRepository _specializationRepository;
        private readonly AppDbContext _appDbContext;
        public LawyerService(ILawyerRepository lawyerRepository, ISpecializationRepository specializationRepository,
            AppDbContext appDbContext)
        {
            _lawyerRepository = lawyerRepository;
            _specializationRepository = specializationRepository;
            _appDbContext = appDbContext;
        }
        public async Task<ResponseModel<string>> UpdateLawyerAsync(LawyerDTO lawyerDTO)
        {
            Data.Models.Lawyer lawyer = await _lawyerRepository.GetByIdAsync(lawyerDTO.Id);
            Location location = (await _appDbContext.Locations.Where(e => e.NormalizedName == lawyerDTO.Location.ToUpper()).FirstOrDefaultAsync())!;
            Specialization specialization = await _specializationRepository.GetByNameAsync(lawyerDTO.Specialization.ToUpper());
            if (lawyer == null)
            {
                return new ResponseModel<string>
                {
                    Success = false,
                    Message = "Failed to update lawyer",
                    StatusCode = 500
                };
            }
            if(location == null && specialization != null)
            {
                await _lawyerRepository.UpdateAsync(new Data.Models.Lawyer
                {
                    Id = lawyerDTO.Id,
                    SpecializationId = specialization.Id,
                    Location = lawyer.Location
                });
                return new ResponseModel<string>
                {
                    Success = false,
                    Message = "updated successfully",
                    StatusCode = 200
                };
            }
            if (location != null && specialization == null)
            {
                await _lawyerRepository.UpdateAsync(new Data.Models.Lawyer
                {
                    Id = lawyerDTO.Id,
                    Location=location.NormalizedName,
                    SpecializationId=lawyer.SpecializationId
                });
                return new ResponseModel<string>
                {
                    Success = false,
                    Message = "updated successfully",
                    StatusCode = 200
                };
            }
            if (location != null && specialization != null)
            {
                await _lawyerRepository.UpdateAsync(new Data.Models.Lawyer
                {
                    Id = lawyerDTO.Id,
                    Location = location.NormalizedName,
                    SpecializationId = specialization.Id,
                });
                return new ResponseModel<string>
                {
                    Success = false,
                    Message = "updated successfully",
                    StatusCode = 200
                };
            }
            return new ResponseModel<string>
            {
                Success = false,
                Message = "invalid location and specialization",
                StatusCode = 500
            };

        }
    }
}
