using System;
using System.ComponentModel.DataAnnotations;

namespace DaoMinhHieu0021867.Dtos.Technician
{
    public class TechnicianDto0021867De11005
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã kỹ thuật viên là bắt buộc")]
        [StringLength(50)]
        public required string MaKyThuatVien { get; set; }

        [Required(ErrorMessage = "Tên kỹ thuật viên là bắt buộc")]
        [StringLength(100)]
        public required string TenKyThuatVien { get; set; }

        [Required(ErrorMessage = "CCCD là bắt buộc")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "CCCD phải có đúng 12 ký tự")]
        public required string CCCD { get; set; }

        [Required]
        public DateTime NgayBatDau { get; set; }

        public string GetTrimmedMaKyThuatVien() => MaKyThuatVien?.Trim();
        public string GetTrimmedTenKyThuatVien() => TenKyThuatVien?.Trim();
        public string GetTrimmedCCCD() => CCCD?.Trim();
    }
} 