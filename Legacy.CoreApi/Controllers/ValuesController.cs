using System.Collections.Generic;
using System.Linq;
using Legacy.CoreApi.Data;
using Legacy.CoreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Legacy.CoreApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDataStore _dataStore = new InMemoryDataStore();

        // GET api/values
        [HttpGet]
        public IEnumerable<Value> Get()
        {
            return _dataStore.GetAll.Cast<Value>();
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public Value Get(int id)
        {
            return _dataStore.GetAll[id] as Value;
        }

        // POST api/values
        [HttpPost]
        [Produces("application/json", Type = typeof(Value))]
        public IActionResult Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dataStore.Add(value);
            return CreatedAtAction("Get", new {id = value.Id}, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
