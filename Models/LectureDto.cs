using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Models
{
    public class LectureDto
    {
        [Required]
        public string Author { get; set; }
        [Required]
        public string Topic { get; set; }
        public string Description { get; set; }
    }
}
