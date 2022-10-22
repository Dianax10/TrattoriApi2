using Microsoft.AspNetCore.Mvc;
using TrattoriApi.Models;
using TrattoriApi.Services;

namespace TrattoriApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrattoreController : ControllerBase
    {
        private readonly ITrattoriService _trattoreServices= new TrattoriServices();

        [HttpPost]
        public IActionResult Post([FromBody] SimpleTrattore trattore)
        {
            var trattoreAdd =_trattoreServices.AddTrattore(trattore);
            return Created("Oggetto Creato",trattoreAdd);
        }
   
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TrattoreController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<TrattoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TrattoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
