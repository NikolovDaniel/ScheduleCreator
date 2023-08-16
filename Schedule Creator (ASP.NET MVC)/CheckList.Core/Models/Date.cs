using System.ComponentModel.DataAnnotations;

namespace CheckList.Core.Models
{
    public class Date
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
