using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Zadatak1.Models;
using Zadatak1.Repositories;

namespace Zadatak1.Controllers
{
    public class KategorijaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetKategorije()
        {
            return Ok(KategorijaRepository.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetKategorija(int id)
        {
            var kategorijaFromDb = KategorijaRepository.GetById(id);

            if (kategorijaFromDb == null)
                return NotFound();

            return Ok(kategorijaFromDb);
        }

        [HttpPost]
        public IHttpActionResult CreateKategorija([FromBody] Kategorija kategorija)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            KategorijaRepository.InsertKategorija(kategorija);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateKategorija(int id, [FromBody] Kategorija kategorija)
        {
            var kategorijaFromDb = KategorijaRepository.GetById(id);

            if (kategorijaFromDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            KategorijaRepository.UpdateKategorija(kategorija);

            return Ok("Kategorija ažurirana");
        }

        [HttpDelete]
        public IHttpActionResult DeleteKategorija(int id)
        {
            var kategorijaFromDb = KategorijaRepository.GetById(id);

            if (kategorijaFromDb == null)
                return NotFound();

            try
            {
                KategorijaRepository.DeleteKategorija(id);
                return Ok("Kategorija je obrisana");

            }
            catch (System.Exception)
            {
                return BadRequest("Proizvod nije obrisan");
            }

        }
    }
}