using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DaoMinhHieu0021867.DbContexts;
using DaoMinhHieu0021867.Dtos.Equipment;
using DaoMinhHieu0021867.Entities;
using DaoMinhHieu0021867.Exceptions;
using DaoMinhHieu0021867.Services.Interfaces;

namespace DaoMinhHieu0021867.Services.Implements
{
    public class EquipmentService0021867De11005 : IEquipmentService0021867De11005
    {
        private readonly ApplicationDbContext0021867De11005 _context;

        public EquipmentService0021867De11005(ApplicationDbContext0021867De11005 context)
        {
            _context = context;
        }

        public async Task<EquipmentDto0021867De11005> CreateEquipmentAsync(EquipmentDto0021867De11005 equipmentDto)
        {
            var maThietBi = equipmentDto.GetTrimmedMaThietBi();
            var tenThietBi = equipmentDto.GetTrimmedTenThietBi();

            if (await _context.Equipment.AnyAsync(e => e.MaThietBi == maThietBi))
                throw new UserFriendlyException0021867De11005("Mã thiết bị đã tồn tại");

            if (await _context.Equipment.AnyAsync(e => e.TenThietBi == tenThietBi))
                throw new UserFriendlyException0021867De11005("Tên thiết bị đã tồn tại");

            var equipment = new Equipment0021867De11005
            {
                MaThietBi = maThietBi,
                TenThietBi = tenThietBi
            };

            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();

            equipmentDto.Id = equipment.Id;
            return equipmentDto;
        }

        public async Task<EquipmentDto0021867De11005> UpdateEquipmentAsync(int id, EquipmentDto0021867De11005 equipmentDto)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy thiết bị");

            var maThietBi = equipmentDto.GetTrimmedMaThietBi();
            var tenThietBi = equipmentDto.GetTrimmedTenThietBi();

            if (await _context.Equipment.AnyAsync(e => e.MaThietBi == maThietBi && e.Id != id))
                throw new UserFriendlyException0021867De11005("Mã thiết bị đã tồn tại");

            if (await _context.Equipment.AnyAsync(e => e.TenThietBi == tenThietBi && e.Id != id))
                throw new UserFriendlyException0021867De11005("Tên thiết bị đã tồn tại");

            equipment.MaThietBi = maThietBi;
            equipment.TenThietBi = tenThietBi;

            await _context.SaveChangesAsync();
            return equipmentDto;
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy thiết bị");

            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task<(List<EquipmentDto0021867De11005> Equipment, int TotalPages)> GetEquipmentAsync(int pageIndex, int pageSize, string keyword)
        {
            var query = _context.Equipment.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(e => e.TenThietBi.Contains(keyword) || e.MaThietBi.Contains(keyword));
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var equipment = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new EquipmentDto0021867De11005
                {
                    Id = e.Id,
                    MaThietBi = e.MaThietBi,
                    TenThietBi = e.TenThietBi
                })
                .ToListAsync();

            return (equipment, totalPages);
        }
    }
} 