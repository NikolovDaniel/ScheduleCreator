using System;
using CheckList.Core.Contracts;
using CheckList.Core.Models;
using CheckList.Infrastructure.Contracts;

namespace CheckList.Core.Services
{
    public class CheckListService : ICheckListService
    {
        private readonly IRepository repo;
        public CheckListService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Date> GetDate(DateTime date)
        {
            return await repo.GetDate(date);
        }
        public async Task AddDate(Date date)
        {
            await repo.AddDate(date);
        }
        public async Task CreateCheckList(List<GoalItem> goalItems, Motivation motivation, List<ScheduleItem> scheduleItems)
        {
            await repo.CreateCheckList(goalItems, motivation, scheduleItems);
        }

        public async Task<IEnumerable<Date>> GetDates()
        {
            return await repo.GetDates();
        }

        public async Task<IEnumerable<GoalItem>> GetGoalItems(Guid id)
        {
            return await repo.GetGoalItems(id);
        }

        public async Task<IEnumerable<ScheduleItem>> GetScheduleItems(Guid id)
        {
            return await repo.GetScheduleItems(id);
        }

        public async Task<Motivation> GetMotivation(Guid id)
        {
            return await repo.GetMotivation(id);
        }
    }
}
