using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DaoMinhHieu0021867.Services.Interfaces;
using DaoMinhHieu0021867.Dtos.Equipment;
using DaoMinhHieu0021867.Exceptions;

namespace DaoMinhHieu0021867.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController0021867De11005 : ControllerBase
    {
        private readonly IEquipmentService0021867De11005 _equipmentService;

        public EquipmentController0021867De11005(IEquipmentService0021867De11005 equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment([FromBody] EquipmentDto0021867De11005 equipmentDto)
        {
            try
            {
                var result = await _equipmentService.CreateEquipmentAsync(equipmentDto);
                return Ok(result);
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipment(int id, [FromBody] EquipmentDto0021867De11005 equipmentDto)
        {
            try
            {
                var result = await _equipmentService.UpdateEquipmentAsync(id, equipmentDto);
                return Ok(result);
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            try
            {
                await _equipmentService.DeleteEquipmentAsync(id);
                return Ok(new { message = "Xóa thiết bị thành công" });
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEquipment([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string keyword = null)
        {
            try
            {
                var (equipment, totalPages) = await _equipmentService.GetEquipmentAsync(pageIndex, pageSize, keyword);
                return Ok(new { equipment, totalPages });
            }
            catch (UserFriendlyException0021867De11005 ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 