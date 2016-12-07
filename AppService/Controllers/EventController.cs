using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Data;
using WebApp.Models;

namespace AppService.Controllers
{
    public class EventController : ApiController
    {
        private readonly IDataRepository _db;

        public IEnumerable<Event> GetAllEvents()
        {
            return _db.GetAllEvents();
        }

        public IHttpActionResult GetEvent(int id)
        {
            var Event = _db.GetAllEvents().FirstOrDefault((e) => e.EventID == id);
            if (Event == null)
            {
                return NotFound();
            }
            return Ok(Event);
        }
    }
}
