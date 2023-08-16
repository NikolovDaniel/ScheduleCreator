using CheckList.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CheckList.Models
{
    public class DateViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        public string[] GoalItems { get; set; } = null!;
        public string[] ScheduleItems { get; set; } = null!;
        public string Motivaton { get; set; } = null!;
    }
}
