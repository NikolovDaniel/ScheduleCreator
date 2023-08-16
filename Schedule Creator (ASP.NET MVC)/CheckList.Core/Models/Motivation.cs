using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.Core.Models
{
    public class Motivation
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Content { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Date))]
        public Guid DateId { get; set; }
        public Date Date { get; set; } = null!;
    }
}
