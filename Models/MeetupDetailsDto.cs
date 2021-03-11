using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Models
{
    public class MeetupDetailsDto
    {
        public string Name { get; set; }
        public string Organizes { get; set; }
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public List<LectureDto> Lecture { get; set; }


    }
}
