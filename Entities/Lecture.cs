using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Entities
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public virtual Meetup Meetup { get; set; }
        public int MeetupId { get; set; }
    }
}
