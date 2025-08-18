using System.ComponentModel.DataAnnotations;

namespace DaoMinhHieu0021867.Dtos.Equipment
{
    public class EquipmentDto0021867De11005
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã thiết bị là bắt buộc")]
        [StringLength(50)]
        public required string MaThietBi { get; set; }

        [Required(ErrorMessage = "Tên thiết bị là bắt buộc")]
        [StringLength(100)]
        public required string TenThietBi { get; set; }

        public string GetTrimmedMaThietBi() => MaThietBi?.Trim();
        public string GetTrimmedTenThietBi() => TenThietBi?.Trim();
    }
} 