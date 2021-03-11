using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Entities
{
    public class Meetup
    {
        // Date base can recognise Id
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organizes { get; set; }
        public DateTime Date { get; set; }
        public bool IsPrivate { get; set; }
        public virtual Location Location { get; set; }
        // One meetup can have some lectures but location is unic
        public virtual List<Lecture> Lectures { get; set; }


    }
}
