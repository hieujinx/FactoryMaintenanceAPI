using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DaoMinhHieu0021867.Services.Interfaces;
using DaoMinhHieu0021867.Dtos.Technician;
using DaoMinhHieu0021867.Exceptions;

namespace DaoMinhHieu0021867.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnicianController0021867De11005 : ControllerBase
    {
        private readonly ITechnicianService0021867De11005 _technicianService;

        public TechnicianController0021867De11005(ITechnicianService0021867De11005 technicianService)
        {
            _technicianService = technicianService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTechnician([FromBody] TechnicianDto0021867De11005 technicianDto)
        {
            try
            {
                var result = await _technicianService.CreateTechnicianAsync(technicianDto);
                return Ok(result);
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnician(int id, [FromBody] TechnicianDto0021867De11005 technicianDto)
        {
            try
            {
                var result = await _technicianService.UpdateTechnicianAsync(id, technicianDto);
                return Ok(result);
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnician(int id)
        {
            try
            {
                await _technicianService.DeleteTechnicianAsync(id);
                return Ok(new { message = "Xóa kỹ thuật viên thành công" });
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTechnicians([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string keyword = null)
        {
            try
            {
                var (technicians, totalPages) = await _technicianService.GetTechniciansAsync(pageIndex, pageSize, keyword);
                return Ok(new { technicians, totalPages });
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{technicianId}/most-repaired-equipment")]
        public async Task<IActionResult> GetMostRepairedEquipment(int technicianId)
        {
            try
            {
                var equipment = await _technicianService.GetMostRepairedEquipmentAsync(technicianId);
                return Ok(equipment);
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 