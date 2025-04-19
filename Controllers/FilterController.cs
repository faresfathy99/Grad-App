using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MizanGraduationProject.Data.DTOs;
using MizanGraduationProject.Data.Models.ResponseSchema;
using MizanGraduationProject.Services.Filter;
using MizanGraduationProject.Services.Lawyer;

namespace MizanGraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private IFilterService _filterService;
        public FilterController(IFilterService filterService)
        {
           _filterService = filterService;
        }

        [HttpPost("filter-lawyers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetNewVerifyEmailCode([FromBody] FilterLawyersDTO filterLawyersDTO)
        {
            try
            {
                var response = await _filterService.FilterLawyers(filterLawyersDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<bool>
                {
                    Message = ex.Message,
                    Success = false,
                    StatusCode = 500
                });
            }
        }
    }
}
