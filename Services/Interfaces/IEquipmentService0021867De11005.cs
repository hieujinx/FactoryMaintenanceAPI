using System.Threading.Tasks;
using System.Collections.Generic;
using DaoMinhHieu0021867.Dtos.Equipment;

namespace DaoMinhHieu0021867.Services.Interfaces
{
    public interface IEquipmentService0021867De11005
    {
        Task<EquipmentDto0021867De11005> CreateEquipmentAsync(EquipmentDto0021867De11005 equipmentDto);
        Task<EquipmentDto0021867De11005> UpdateEquipmentAsync(int id, EquipmentDto0021867De11005 equipmentDto);
        Task DeleteEquipmentAsync(int id);
        Task<(List<EquipmentDto0021867De11005> Equipment, int TotalPages)> GetEquipmentAsync(int pageIndex, int pageSize, string keyword);
    }
} 