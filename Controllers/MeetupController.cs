using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tutorial.Entities;
using tutorial.Models;

namespace tutorial.Controllers
{
    [Route("api/meetups")]
    public class MeetupController : ControllerBase
    {
        public MeetupController(MeetupContext meetupContext, IMapper mapper)
        {
            MeetupContext = meetupContext;
            Mapper = mapper;
        }

        public MeetupContext MeetupContext { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        public ActionResult<List<Meetup>> Get()
        {
            var meetups = MeetupContext.Meetups.Include(m => m.Location).ToList();
            var meetupDtos = Mapper.Map<List<MeetupDetailsDto>>(meetups);
            return Ok(meetupDtos);
        }

        [HttpGet("{name}")]
        public ActionResult<List<MeetupDetailsDto>> Get(string name)
        {
            var meetup = MeetupContext.Meetups
                .Include(m => m.Location)
                .Include(m => m.Lectures)
                .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.Replace(" ", "-").ToLower());

            if (meetup == null)
                return NotFound();

            var meetupDtos = Mapper.Map<MeetupDetailsDto>(meetup);
            return Ok(meetupDtos);
        }

        [HttpPost]
        public ActionResult Post([FromBody] MeetupDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // does Required field are valid and mindlenght in MeetupDto
            }

            var meetup = Mapper.Map<Meetup>(model); // map model on Meetup
            MeetupContext.Meetups.Add(meetup);
            MeetupContext.SaveChanges();

            var key = meetup.Name.Replace(" ", "-").ToLower();
            return Created("api/meetups/" + key, null);
        }

        [HttpPut("{name}")]
        public ActionResult Put(string name, [FromBody] MeetupDto model)
        {
            var meetup = MeetupContext.Meetups
               .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.Replace(" ", "-").ToLower());

            if (meetup == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // does Required field are valid and mindlenght in MeetupDto
            }

            meetup.Name = model.Name;
            meetup.Organizes = model.Organizes;
            meetup.Date = model.Date;
            meetup.IsPrivate = model.IsPrivate;

            MeetupContext.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            var meetup = MeetupContext.Meetups
               .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.Replace(" ", "-").ToLower());

            if (meetup == null)
                return NotFound();

            MeetupContext.Remove(meetup);
            MeetupContext.SaveChanges();
            return NoContent();
        }


    }
}
