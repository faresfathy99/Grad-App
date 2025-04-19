using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MizanGraduationProject.Data.DTOs;
using MizanGraduationProject.Data.Models.ResponseSchema;
using MizanGraduationProject.Services.Lawyer;

namespace MizanGraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawyerController : ControllerBase
    {
        private ILawyerService _lawyerService;
        public LawyerController(ILawyerService lawyerService)
        {
            _lawyerService = lawyerService;
        }

        [HttpPut("update-lawyer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetNewVerifyEmailCode(LawyerDTO lawyerDTO)
        {
            try
            {
                var response = await _lawyerService.UpdateLawyerAsync(lawyerDTO);
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
