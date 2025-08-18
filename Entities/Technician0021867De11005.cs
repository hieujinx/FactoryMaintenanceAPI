using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaoMinhHieu0021867.Entities
{
    public class Technician0021867De11005
    {
        public Technician0021867De11005()
        {
            Repairs = new List<Repair0021867De11005>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public required string MaKyThuatVien { get; set; }

        [Required]
        public required string TenKyThuatVien { get; set; }

        [Required]
        public required string CCCD { get; set; }

        public DateTime NgayBatDau { get; set; }

        public virtual ICollection<Repair0021867De11005> Repairs { get; set; }
    }
} 