using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Zadatak1.Models;
using Zadatak1.Repositories;

namespace Zadatak1.Controllers
{
    public class ProizvodController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetProizvodi()
        {
            return Ok(ProizvodRepository.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetProizvod(int id)
        {
            var proizvodFromDb = ProizvodRepository.GetById(id);

            if (proizvodFromDb == null)
                return NotFound();

            return Ok(proizvodFromDb);
        }

        [HttpPost]
        public IHttpActionResult CreateProizvod([FromBody] Proizvod proizvod)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            ProizvodRepository.InsertProizvod(proizvod);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateProizvod(int id, [FromBody] Proizvod proizvod)
        {
            var proizvodFromDb = ProizvodRepository.GetById(id);

            if (proizvodFromDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            ProizvodRepository.UpdateProizvod(proizvod);

            return Ok("Proizvod ažuriran");
        }

        [HttpDelete]
        public IHttpActionResult DeleteProizvod(int id)
        {
            var proizvodFromDb = ProizvodRepository.GetById(id);

            if (proizvodFromDb == null)
                return NotFound();

            try
            {
                ProizvodRepository.DeleteProizvod(id);
                return Ok("Proizvod obrisan");

            }
            catch (System.Exception)
            {
                return BadRequest("Proizvod nije obrisan");
            }

        }
    }
}