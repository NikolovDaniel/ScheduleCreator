using CheckList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.Infrastructure.Contracts
{
    public interface IRepository
    {
        Task<Date> GetDate(DateTime date);
        Task AddDate(Date date);
        Task<IEnumerable<Date>> GetDates();
        Task CreateCheckList(List<GoalItem> goalItems, Motivation motivation, List<ScheduleItem> scheduleItems);
        Task<IEnumerable<ScheduleItem>> GetScheduleItems(Guid id);
        Task<IEnumerable<GoalItem>> GetGoalItems(Guid id);
        Task<Motivation> GetMotivation(Guid id);
    }
}
