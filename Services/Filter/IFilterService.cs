using MizanGraduationProject.Data.DTOs;
using MizanGraduationProject.Data.Models.ResponseSchema;

namespace MizanGraduationProject.Services.Filter
{
    public interface IFilterService
    {
        Task<ResponseModel<List<object>>> FilterLawyers(FilterLawyersDTO filterLawyersDTO);
    }
}
