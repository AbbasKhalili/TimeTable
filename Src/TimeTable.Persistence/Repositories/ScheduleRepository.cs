using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTable.Domain.Schedules;

namespace TimeTable.Persistence.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly TimeTableDbContext _context;

        public ScheduleRepository(TimeTableDbContext context)
        {
            _context = context;
        }

        public async Task Create(Schedule entity)
        {
            await _context.Schedules.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Schedule> GetBy(long id)
        {
            return await _context.Schedules.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Update(Schedule entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Schedule entity)
        {
            _context.Schedules.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Schedule>> GetAll()
        {
            return await _context.Schedules.ToListAsync();
        }
    }
}