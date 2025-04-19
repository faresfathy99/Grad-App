using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MizanGraduationProject.Data;
using MizanGraduationProject.Data.Classes;

namespace MizanGraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private AppDbContext _AppDbContext;
        public SpecializationController(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }

        [HttpPost("fill-specializations")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> FillLocationsAsync()
        {
            try
            {
                if (await _AppDbContext.Specializations.CountAsync() > 0)
                {
                    return StatusCode(403, new
                    {
                        Message = "Specializations already exists",
                        Success = false,
                        StatusCode = 403
                    });
                }
                foreach (var specialization in Specializations.lawyerSpecializations)
                {
                    await _AppDbContext.Specializations.AddAsync(new Data.Models.Specialization
                    {
                        Name = specialization,
                        NormalizedName = specialization.ToUpper(),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    });
                    await _AppDbContext.SaveChangesAsync();
                }
                return StatusCode(201, new
                {
                    Message = "Specializations added successfully",
                    Success = true,
                    StatusCode = 201
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = ex.Message,
                    Success = false,
                    StatusCode = 500
                });
            }
        }

        [HttpGet("get-specializations")]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLocationsAsync()
        {
            try
            {
                if (await _AppDbContext.Specializations.CountAsync() > 0)
                {
                    var Specializations = await _AppDbContext.Specializations
                    .Select(x => new
                    {
                        x.NormalizedName
                    })
                    .ToListAsync();
                    return StatusCode(200, new
                    {
                        Message = "Specializations found successfully",
                        Success = true,
                        StatusCode = 200,
                        Specializations = Specializations
                    });
                }
                return StatusCode(404, new
                {
                    Message = "Locations not found",
                    Success = false,
                    StatusCode = 404
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = ex.Message,
                    Success = false,
                    StatusCode = 500
                });
            }
        }

    }
}
