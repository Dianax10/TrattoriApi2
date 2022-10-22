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
        public IActionResult GetAllTrattori()
        {
          var trattori= _trattoreServices.GetAll();
            if (trattori==null)
                return NotFound("Trattore not Found");

            return Ok(trattori);
        }

       
        [HttpGet("{idTrattore}")]
        public IActionResult GetById(int idTrattore)
        {
           var trattoriFound=_trattoreServices.GetById(idTrattore);
            if (trattoriFound == null)
                return NotFound("Trattore non trovato");

            return Ok(trattoriFound);

        }
        [HttpGet("{colore}")]
        public IActionResult GetByColor(string colore)
        {
            var trattoriFound = _trattoreServices.GetByFilter(colore);
            if (trattoriFound == null)
                return NotFound("Trattore non trovato");

            return Ok(trattoriFound);

        }

        [HttpDelete("{idTrattore}")]
        public IActionResult Delete(int idTrattore)
        {
            var trattori= _trattoreServices.Delete(idTrattore);
            if (trattori == null)
                return BadRequest("Impossibile eliminare Trattore non esistente");
            return Ok(trattori);
        }


        [HttpPut("{idTrattore}")]
        public void Put(int idTrattore, [FromBody] SimpleTrattore trattore)
        {

        }

       
    }
}
