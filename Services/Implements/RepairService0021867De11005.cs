using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DaoMinhHieu0021867.DbContexts;
using DaoMinhHieu0021867.Dtos.Repair;
using DaoMinhHieu0021867.Entities;
using DaoMinhHieu0021867.Exceptions;
using DaoMinhHieu0021867.Services.Interfaces;

namespace DaoMinhHieu0021867.Services.Implements
{
    public class RepairService0021867De11005 : IRepairService0021867De11005
    {
        private readonly ApplicationDbContext0021867De11005 _context;

        public RepairService0021867De11005(ApplicationDbContext0021867De11005 context)
        {
            _context = context;
        }

        public async Task<RepairDto0021867De11005> CreateRepairAsync(RepairDto0021867De11005 repairDto)
        {
            var technician = await _context.Technicians.FindAsync(repairDto.TechnicianId);
            if (technician == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy kỹ thuật viên");

            var equipment = await _context.Equipment.FindAsync(repairDto.EquipmentId);
            if (equipment == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy thiết bị");

            var repair = new Repair0021867De11005
            {
                TechnicianId = repairDto.TechnicianId,
                EquipmentId = repairDto.EquipmentId,
                SoLanSua = repairDto.SoLanSua,
                NgaySua = repairDto.NgaySua,
                Technician = technician!,
                Equipment = equipment!
            };

            _context.Repairs.Add(repair);
            await _context.SaveChangesAsync();

            repairDto.Id = repair.Id;
            return repairDto;
        }

        public async Task<RepairDto0021867De11005> UpdateRepairAsync(int id, RepairDto0021867De11005 repairDto)
        {
            var repair = await _context.Repairs.FindAsync(id);
            if (repair == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy lịch sử sửa chữa");

            var technician = await _context.Technicians.FindAsync(repairDto.TechnicianId);
            if (technician == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy kỹ thuật viên");

            var equipment = await _context.Equipment.FindAsync(repairDto.EquipmentId);
            if (equipment == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy thiết bị");

            repair.TechnicianId = repairDto.TechnicianId;
            repair.EquipmentId = repairDto.EquipmentId;
            repair.SoLanSua = repairDto.SoLanSua;
            repair.NgaySua = repairDto.NgaySua;

            await _context.SaveChangesAsync();
            return repairDto;
        }

        public async Task DeleteRepairAsync(int id)
        {
            var repair = await _context.Repairs.FindAsync(id);
            if (repair == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy lịch sử sửa chữa");

            _context.Repairs.Remove(repair);
            await _context.SaveChangesAsync();
        }

        public async Task<(List<RepairDto0021867De11005> Repairs, int TotalPages)> GetRepairsAsync(int pageIndex, int pageSize, string keyword)
        {
            var query = _context.Repairs
                .Include(r => r.Technician)
                .Include(r => r.Equipment)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(r => 
                    r.Technician.TenKyThuatVien.Contains(keyword) || 
                    r.Equipment.TenThietBi.Contains(keyword));
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var repairs = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new RepairDto0021867De11005
                {
                    Id = r.Id,
                    TechnicianId = r.TechnicianId,
                    EquipmentId = r.EquipmentId,
                    SoLanSua = r.SoLanSua,
                    NgaySua = r.NgaySua
                })
                .ToListAsync();

            return (repairs, totalPages);
        }
    }
} 