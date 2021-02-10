using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTable.Domain.Reserves;

namespace TimeTable.Persistence.Repositories
{
    public class ReserveRepository : IReserveRepository
    {
        private readonly TimeTableDbContext _context;

        public ReserveRepository(TimeTableDbContext context)
        {
            _context = context;
        }

        public async Task Create(Reserve entity)
        {
            await _context.Reserves.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Reserve> GetBy(long id)
        {
            return await _context.Reserves.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Update(Reserve entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Reserve entity)
        {
            _context.Reserves.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reserve>> GetAll()
        {
            return await _context.Reserves.ToListAsync();
        }
        
        public async Task<List<Reserve>> GetByTime(DateTime scheduleTime, long scheduleId)
        {
            return await _context.Reserves.Include(a => a.Schedule)
                .Where(a => a.ScheduleId == scheduleId && a.Schedule.Time == scheduleTime).ToListAsync();
        }
    }
}