using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaoMinhHieu0021867.Entities
{
    public class Equipment0021867De11005
    {
        public Equipment0021867De11005()
        {
            Repairs = new List<Repair0021867De11005>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public required string MaThietBi { get; set; }

        [Required]
        public required string TenThietBi { get; set; }

        public virtual ICollection<Repair0021867De11005> Repairs { get; set; }
    }
} 