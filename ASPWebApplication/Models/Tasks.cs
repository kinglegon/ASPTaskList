using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPWebApplication.Models
{
    public partial class Tasks
    {
        public int TaskId { get; set; }

        [Display(Name = "Task Time")]
        public DateTime? TaskDate { get; set; }

        [Display(Name = "Person")]
        [Required]
        public int? PersonId { get; set; }

        [StringLength(200)]
        [Required]
        public string Task { get; set; }

        public bool Completed { get; set; }

        public People Person { get; set; }
    }
}
