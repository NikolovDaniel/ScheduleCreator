using CheckList.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CheckList.Models
{
    public class DateAndItemsViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<GoalItem> GoalItems { get; set; } = null!;
        public IEnumerable<ScheduleItem> ScheduleItems { get; set; } = null!;
        public Motivation Motivaton { get; set; } = null!;
    }
}
