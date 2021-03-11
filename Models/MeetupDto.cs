using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace tutorial.Models
{
    public class MeetupDto
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Organizes { get; set; }
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }
    }
}
