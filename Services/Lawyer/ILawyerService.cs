using MizanGraduationProject.Data.DTOs;
using MizanGraduationProject.Data.Models.ResponseSchema;

namespace MizanGraduationProject.Services.Lawyer
{
    public interface ILawyerService
    {
        Task<ResponseModel<string>> UpdateLawyerAsync(LawyerDTO lawyerDTO);
    }
}
