using System;
using System.Collections.Generic;
using System.Linq;
using Legacy.CoreApi.Data;
using Legacy.CoreApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Legacy.CoreApi.Controllers
{
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly IDataStore _dataStore;

        public LogController(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        
        // GET: api/log
        [HttpGet]
        public IEnumerable<LogEntry> Get()
        {
            return _dataStore.GetAll.Cast<LogEntry>();
        }

        // GET api/log/5
        [HttpGet("{id:int}")]
        public LogEntry Get(int id)
        {
            return _dataStore.GetAll[id] as LogEntry;
        }

        // GET api/log/count
        [HttpGet("count")]
        public int GetCount()
        {
            return _dataStore.Count;
        }


        // POST api/log
        [HttpPost]
        [Produces("application/json", Type = typeof(LogEntry))]
        public IActionResult Post([FromBody]LogEntry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AddNewEntry(entry);
            // REST common practice (good citizen) is to return the location of the new resource
            return CreatedAtAction("Get", new { id = entry.Id }, entry);
        }

        // PUT api/log/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return BadRequest();
        }

        // DELETE api/log/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }

        private void AddNewEntry(LogEntry entry)
        {
            entry.Timestamp = DateTime.Now;
            entry.Id = _dataStore.Count;
            _dataStore.Add(entry);
        }
    }
}
