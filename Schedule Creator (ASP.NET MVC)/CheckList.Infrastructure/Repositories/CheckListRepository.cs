using CheckList.Core.Models;
using CheckList.Infrastructure.Contracts;
using CheckList.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CheckList.Infrastructure.Repositories
{
    public class CheckListRepository : IRepository
    {
        private readonly CheckListDbContext context;
        public CheckListRepository(CheckListDbContext context)
        {
            this.context = context;
        }

        public async Task<Date> GetDate(DateTime date)
        {
            return await context.Dates.FirstOrDefaultAsync(d => d.DateTime == date);
        }
        public async Task AddDate(Date date)
        {
            await context.Dates.AddAsync(date);
            await context.SaveChangesAsync();
        }
        public async Task CreateCheckList(List<GoalItem> goalItems, Motivation motivation, List<ScheduleItem> scheduleItems)
        {
            await context.GoalItems.AddRangeAsync(goalItems);
            await context.Motivations.AddAsync(motivation);
            await context.ScheduleItems.AddRangeAsync(scheduleItems);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Date>> GetDates()
        {
            return await context.Dates.AsNoTracking().OrderByDescending(x => x.DateTime).ToListAsync();
        }

        public async Task<IEnumerable<GoalItem>> GetGoalItems(Guid id)
        {
            return await context.GoalItems.AsNoTracking().Where(x => x.DateId == id).ToListAsync();
        }

        public async Task<IEnumerable<ScheduleItem>> GetScheduleItems(Guid id)
        {
            return await context.ScheduleItems.AsNoTracking().Where(x => x.DateId == id).ToListAsync();
        }

        public async Task<Motivation> GetMotivation(Guid id)
        {
            return await context.Motivations.AsNoTracking().FirstOrDefaultAsync(x => x.DateId == id);
        }
    }
}
