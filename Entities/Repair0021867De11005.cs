using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaoMinhHieu0021867.Entities
{
	public class Repair0021867De11005
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int TechnicianId { get; set; }

		[Required]
		public int EquipmentId { get; set; }

		[Range(0, int.MaxValue)]
		public int SoLanSua { get; set; }

		public DateTime NgaySua { get; set; }

		[ForeignKey("TechnicianId")]
		public required virtual Technician0021867De11005 Technician { get; set; }

		[ForeignKey("EquipmentId")]
		public required virtual Equipment0021867De11005 Equipment { get; set; }
	}
} 