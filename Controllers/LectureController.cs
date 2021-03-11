using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial.Entities;
using tutorial.Models;

namespace tutorial.Controllers
{
    [Route("api/meetups/{meetupName}/lecture")]
    public class LectureController : ControllerBase
    {
        public LectureController(MeetupContext meetupContext, IMapper mapper)
        {
            MeetupContext = meetupContext;
            Mapper = mapper;
        }

        public MeetupContext MeetupContext { get; }
        public IMapper Mapper { get; }

        [HttpPost]
        public ActionResult Post(string meetupName, [FromBody] LectureDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // does Required field are valid and mindlenght in MeetupDto
            }

            var meetup = MeetupContext.Meetups
               .Include(m => m.Lectures)
               .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.Replace(" ", "-").ToLower());

            if (meetup == null)
                return NotFound();

            var lecture = Mapper.Map<Lecture>(model);
            meetup.Lectures.Add(lecture);
            MeetupContext.SaveChanges();

            return Created($"api/meetups/{meetupName}", null);
        }

        [HttpGet]
        public ActionResult Get(string meetupName)
        {
            var meetup = MeetupContext.Meetups
              .Include(m => m.Lectures)
              .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.Replace(" ", "-").ToLower());

            if (meetup == null)
                return NotFound();

            var lectures = Mapper.Map<List<LectureDto>>(meetup.Lectures);
            return Ok(lectures);
        }

        [HttpDelete]
        public ActionResult Delete(string meetupName)
        {
            var meetup = MeetupContext.Meetups
              .Include(m => m.Lectures)
              .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.Replace(" ", "-").ToLower());

            if (meetup == null)
                return NotFound();

            MeetupContext.Lectures.RemoveRange(meetup.Lectures);
            MeetupContext.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(string meetupName, int id)
        {
            var meetup = MeetupContext.Meetups
              .Include(m => m.Lectures)
              .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.Replace(" ", "-").ToLower());

            if (meetup == null)
                return NotFound();

            var lecture = meetup.Lectures.FirstOrDefault(l => l.Id == id);

            if (lecture == null)
                return NotFound();

            MeetupContext.Lectures.Remove(lecture);
            MeetupContext.SaveChanges();
            return NoContent();
        }
    }
}
