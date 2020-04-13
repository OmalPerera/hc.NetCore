using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HC_netCore
{
    [Table("TodoItem")]
    public class TodoItem
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool IsComplete { get; set; }
    }
}
