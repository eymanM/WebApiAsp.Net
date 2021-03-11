using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial.Entities;

namespace tutorial
{
    public class MeetupSeeder
    {
        public MeetupContext MeetupContext { get; }
        public MeetupSeeder(MeetupContext meetupContext)
        {
            MeetupContext = meetupContext;
        }

        public void Seed()
        {
            if(MeetupContext.Database.CanConnect())
            {
                if(!MeetupContext.Meetups.Any())
                {
                    InsertSampleData();
                }
            }
        }

        private void InsertSampleData()
        {
            var meetups = new List<Meetup>
            {
                new Meetup
                {
                    Name = "1",
                    Date = DateTime.Now.AddDays(7),
                    IsPrivate = false,
                    Organizes = "2",
                    Location = new Location
                    {
                        City = "3",
                        Street = "4",
                        PostCode = "5"
                    },
                    Lectures = new List<Lecture>
                    {
                        new Lecture
                        {
                            Author = "6",
                            Topic = "7",
                            Description = "8"
                        },
                        new Lecture
                        {
                            Author = "8",
                            Topic = "9",
                            Description = "10"
                        }
                    }
                },

                new Meetup
                {
                    Name = "11",
                    Date = DateTime.Now.AddDays(7),
                    IsPrivate = false,
                    Organizes = "12",
                    Location = new Location
                    {
                        City = "13",
                        Street = "14",
                        PostCode = "15"
                    },
                    Lectures = new List<Lecture>
                    {
                        new Lecture
                        {
                            Author = "16",
                            Topic = "17",
                            Description = "18"
                        },
                        new Lecture
                        {
                            Author = "19",
                            Topic = "20",
                            Description = "21"
                        }
                    }
                }
            };
            MeetupContext.AddRange(meetups);
            MeetupContext.SaveChanges();
        }
    }
}
