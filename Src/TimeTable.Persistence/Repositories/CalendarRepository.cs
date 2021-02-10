using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTable.Domain.Calendars;

namespace TimeTable.Persistence.Repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly TimeTableDbContext _context;

        public CalendarRepository(TimeTableDbContext context)
        {
            _context = context;
        }

        public async Task Create(Calendar entity)
        {
            await _context.Calendars.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Calendar> GetBy(long id)
        {
            return await _context.Calendars.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Update(Calendar entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Calendar entity)
        {
            _context.Calendars.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Create(List<Calendar> list)
        {
            await _context.Calendars.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }

        public async Task<Calendar> GetByDate(DateTime date)
        {
            return await _context.Calendars.FirstOrDefaultAsync(a => a.Date == date);
        }

        public async Task<List<Calendar>> GetAll()
        {
            return await _context.Calendars.ToListAsync();
        }
    }
}
