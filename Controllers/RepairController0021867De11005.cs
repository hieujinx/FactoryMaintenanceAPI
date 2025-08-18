using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DaoMinhHieu0021867.Services.Interfaces;
using DaoMinhHieu0021867.Dtos.Repair;
using DaoMinhHieu0021867.Exceptions;

namespace DaoMinhHieu0021867.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairController0021867De11005 : ControllerBase
    {
        private readonly IRepairService0021867De11005 _repairService;

        public RepairController0021867De11005(IRepairService0021867De11005 repairService)
        {
            _repairService = repairService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRepair([FromBody] RepairDto0021867De11005 repairDto)
        {
            try
            {
                var result = await _repairService.CreateRepairAsync(repairDto);
                return Ok(result);
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepair(int id, [FromBody] RepairDto0021867De11005 repairDto)
        {
            try
            {
                var result = await _repairService.UpdateRepairAsync(id, repairDto);
                return Ok(result);
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepair(int id)
        {
            try
            {
                await _repairService.DeleteRepairAsync(id);
                return Ok(new { message = "Xóa lịch sử sửa chữa thành công" });
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRepairs([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string keyword = null)
        {
            try
            {
                var (repairs, totalPages) = await _repairService.GetRepairsAsync(pageIndex, pageSize, keyword);
                return Ok(new { repairs, totalPages });
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 