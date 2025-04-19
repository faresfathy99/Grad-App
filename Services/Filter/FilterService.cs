using MizanGraduationProject.Data.DTOs;
using MizanGraduationProject.Data.Models.ResponseSchema;
using MizanGraduationProject.Repositories.Lawyer;

namespace MizanGraduationProject.Services.Filter
{
    public class FilterService : IFilterService
    {
        
        private readonly ILawyerRepository _lawyerRepository;
        public FilterService(ILawyerRepository lawyerRepository)
        {
            _lawyerRepository = lawyerRepository;
        }
        public async Task<ResponseModel<List<object>>> FilterLawyers(FilterLawyersDTO filterLawyersDTO)
        {
            List<object> result = (await _lawyerRepository.GetAllWithFilterAsync(filterLawyersDTO)).ToList();
            return new ResponseModel<List<object>>
            {
                Success = true,
                Message = "Lawyers Found Successfully",
                StatusCode = 200,
                Model = result
            };
        }
    }
}
