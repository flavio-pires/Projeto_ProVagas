using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProVagas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusEstagiosController : ControllerBase
    {
        // GET: api/<StatusEstagiosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StatusEstagiosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatusEstagiosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatusEstagiosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatusEstagiosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
