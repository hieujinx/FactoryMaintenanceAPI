using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DaoMinhHieu0021867.DbContexts;
using DaoMinhHieu0021867.Dtos.Technician;
using DaoMinhHieu0021867.Dtos.Equipment;
using DaoMinhHieu0021867.Entities;
using DaoMinhHieu0021867.Exceptions;
using DaoMinhHieu0021867.Services.Interfaces;

namespace DaoMinhHieu0021867.Services.Implements
{
    public class TechnicianService0021867De11005 : ITechnicianService0021867De11005
    {
        private readonly ApplicationDbContext0021867De11005 _context;

        public TechnicianService0021867De11005(ApplicationDbContext0021867De11005 context)
        {
            _context = context;
        }

        public async Task<TechnicianDto0021867De11005> CreateTechnicianAsync(TechnicianDto0021867De11005 technicianDto)
        {
            var maKyThuatVien = technicianDto.GetTrimmedMaKyThuatVien();
            var tenKyThuatVien = technicianDto.GetTrimmedTenKyThuatVien();
            var cccd = technicianDto.GetTrimmedCCCD();

            if (await _context.Technicians.AnyAsync(t => t.MaKyThuatVien == maKyThuatVien))
                throw new UserFriendlyException0021867De11005("Mã kỹ thuật viên đã tồn tại");

            if (await _context.Technicians.AnyAsync(t => t.TenKyThuatVien == tenKyThuatVien))
                throw new UserFriendlyException0021867De11005("Tên kỹ thuật viên đã tồn tại");

            if (await _context.Technicians.AnyAsync(t => t.CCCD == cccd))
                throw new UserFriendlyException0021867De11005("CCCD đã tồn tại");

            var technician = new Technician0021867De11005
            {
                MaKyThuatVien = maKyThuatVien,
                TenKyThuatVien = tenKyThuatVien,
                CCCD = cccd,
                NgayBatDau = technicianDto.NgayBatDau
            };

            _context.Technicians.Add(technician);
            await _context.SaveChangesAsync();

            technicianDto.Id = technician.Id;
            return technicianDto;
        }

        public async Task<TechnicianDto0021867De11005> UpdateTechnicianAsync(int id, TechnicianDto0021867De11005 technicianDto)
        {
            var technician = await _context.Technicians.FindAsync(id);
            if (technician == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy kỹ thuật viên");

            var maKyThuatVien = technicianDto.GetTrimmedMaKyThuatVien();
            var tenKyThuatVien = technicianDto.GetTrimmedTenKyThuatVien();
            var cccd = technicianDto.GetTrimmedCCCD();

            if (await _context.Technicians.AnyAsync(t => t.MaKyThuatVien == maKyThuatVien && t.Id != id))
                throw new UserFriendlyException0021867De11005("Mã kỹ thuật viên đã tồn tại");

            if (await _context.Technicians.AnyAsync(t => t.TenKyThuatVien == tenKyThuatVien && t.Id != id))
                throw new UserFriendlyException0021867De11005("Tên kỹ thuật viên đã tồn tại");

            if (await _context.Technicians.AnyAsync(t => t.CCCD == cccd && t.Id != id))
                throw new UserFriendlyException0021867De11005("CCCD đã tồn tại");

            technician.MaKyThuatVien = maKyThuatVien;
            technician.TenKyThuatVien = tenKyThuatVien;
            technician.CCCD = cccd;
            technician.NgayBatDau = technicianDto.NgayBatDau;

            await _context.SaveChangesAsync();
            return technicianDto;
        }

        public async Task DeleteTechnicianAsync(int id)
        {
            var technician = await _context.Technicians.FindAsync(id);
            if (technician == null)
                throw new UserFriendlyException0021867De11005("Không tìm thấy kỹ thuật viên");

            _context.Technicians.Remove(technician);
            await _context.SaveChangesAsync();
        }

        public async Task<(List<TechnicianDto0021867De11005> Technicians, int TotalPages)> GetTechniciansAsync(int pageIndex, int pageSize, string keyword)
        {
            var query = _context.Technicians.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(t => t.TenKyThuatVien.Contains(keyword) || t.CCCD.Contains(keyword));
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var technicians = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new TechnicianDto0021867De11005
                {
                    Id = t.Id,
                    MaKyThuatVien = t.MaKyThuatVien,
                    TenKyThuatVien = t.TenKyThuatVien,
                    CCCD = t.CCCD,
                    NgayBatDau = t.NgayBatDau
                })
                .ToListAsync();

            return (technicians, totalPages);
        }

        public async Task<List<EquipmentDto0021867De11005>> GetMostRepairedEquipmentAsync(int technicianId)
        {
            var maxRepairCount = await _context.Repairs
                .Where(r => r.TechnicianId == technicianId)
                .MaxAsync(r => (int?)r.SoLanSua) ?? 0;

            var mostRepairedEquipment = await _context.Repairs
                .Where(r => r.TechnicianId == technicianId && r.SoLanSua == maxRepairCount)
                .Include(r => r.Equipment)
                .Select(r => new EquipmentDto0021867De11005
                {
                    Id = r.Equipment.Id,
                    MaThietBi = r.Equipment.MaThietBi,
                    TenThietBi = r.Equipment.TenThietBi
                })
                .OrderByDescending(e => e.MaThietBi)
                .ToListAsync();

            return mostRepairedEquipment;
        }
    }
} 