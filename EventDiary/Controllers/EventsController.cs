using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventDiary.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        static  List<Event> events = new List<Event> { new Event { Id = 1, Title = "default event",Start=DateTime.Today },new Event {Title="difault2",Start=DateTime.Today} };
        // GET: api/<EventsController>
        [HttpGet]
        public List<Event> Get()
        {
            return events;
        }

        //// GET api/<EventsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event eve)
        {
            int id = events.Max(e => e.Id) + 1;
            events.Add(new Event { Start = eve.Start, Title = eve.Title, Id = id });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event neweve)
        {
            var eve = events.Find(e => e.Id == id);

            eve.Title = neweve.Title;
            eve.Start = neweve.Start;
            
            eve.End = neweve.End;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            events.Remove(eve);
        }
    }
}
