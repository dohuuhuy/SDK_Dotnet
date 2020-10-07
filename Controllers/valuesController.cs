using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservice_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace microservice_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class valuesController : ControllerBase
    {
        // GET: api/values
        private testdbContext _context;
        
        public valuesController(testdbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult <IEnumerable<string>> Get()
        {
            var students = _context.Student.ToList();

            return Ok(students);
          //  return new string[] { "value1", "value2" };
        }

        // GET: api/values/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
