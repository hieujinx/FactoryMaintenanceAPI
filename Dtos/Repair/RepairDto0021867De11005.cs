using System;
using System.ComponentModel.DataAnnotations;

namespace DaoMinhHieu0021867.Dtos.Repair
{
    public class RepairDto0021867De11005
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ID kỹ thuật viên là bắt buộc")]
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "ID thiết bị là bắt buộc")]
        public int EquipmentId { get; set; }

        [Required(ErrorMessage = "Số lần sửa là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lần sửa phải lớn hơn 0")]
        public int SoLanSua { get; set; }

        [Required(ErrorMessage = "Ngày sửa là bắt buộc")]
        public DateTime NgaySua { get; set; }
    }
} 