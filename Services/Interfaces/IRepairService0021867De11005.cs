using System.Threading.Tasks;
using System.Collections.Generic;
using DaoMinhHieu0021867.Dtos.Repair;

namespace DaoMinhHieu0021867.Services.Interfaces
{
    public interface IRepairService0021867De11005
    {
        Task<RepairDto0021867De11005> CreateRepairAsync(RepairDto0021867De11005 repairDto);
        Task<RepairDto0021867De11005> UpdateRepairAsync(int id, RepairDto0021867De11005 repairDto);
        Task DeleteRepairAsync(int id);
        Task<(List<RepairDto0021867De11005> Repairs, int TotalPages)> GetRepairsAsync(int pageIndex, int pageSize, string keyword);
    }
} 