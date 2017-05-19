using System;
using System.ComponentModel.DataAnnotations;

namespace Legacy.CoreApi.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        [Required]
        public string Details { get; set; }
    }
}
