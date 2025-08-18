using System.Threading.Tasks;
using System.Collections.Generic;
using DaoMinhHieu0021867.Dtos.Technician;
using DaoMinhHieu0021867.Dtos.Equipment;

namespace DaoMinhHieu0021867.Services.Interfaces
{
    public interface ITechnicianService0021867De11005
    {
        Task<TechnicianDto0021867De11005> CreateTechnicianAsync(TechnicianDto0021867De11005 technicianDto);
        Task<TechnicianDto0021867De11005> UpdateTechnicianAsync(int id, TechnicianDto0021867De11005 technicianDto);
        Task DeleteTechnicianAsync(int id);
        Task<(List<TechnicianDto0021867De11005> Technicians, int TotalPages)> GetTechniciansAsync(int pageIndex, int pageSize, string keyword);
        Task<List<EquipmentDto0021867De11005>> GetMostRepairedEquipmentAsync(int technicianId);
    }
} 