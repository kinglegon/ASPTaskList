using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPWebApplication.Models
{
    public partial class People
    {
        public People()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int PersonId { get; set; }

        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        [StringLength(100)]
        public string JobRole { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
