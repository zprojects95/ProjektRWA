
using System.Web.Http;
using Zadatak1.Models;
using Zadatak1.Repositories;

namespace Zadatak1.Controllers
{
    public class PotkategorijaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPotkategorije()
        {
            return Ok(PotkategorijaRepository.GetAll()); ;
        }

        [HttpGet]
        public IHttpActionResult GetPotkategorija(int id)
        {
            var potkategorijaFromDb = PotkategorijaRepository.GetById(id);

            if (potkategorijaFromDb == null)
                return NotFound();

            return Ok(potkategorijaFromDb);
        }

        [HttpPost]
        public IHttpActionResult CreatePotkategorija([FromBody] Potkategorija potkategorija)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            PotkategorijaRepository.InsertPotkategorija(potkategorija);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdatePotkategorija(int id, [FromBody] Potkategorija potkategorija)
        {
            var potkategorijaFromDb = PotkategorijaRepository.GetById(id);

            if (potkategorijaFromDb == null)  
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            PotkategorijaRepository.UpdatePotkategorija(potkategorija);

            return Ok("Potkategorija ažurirana");
        }

        [HttpDelete]
        public IHttpActionResult DeletePotkategorija(int id)
        {
            var potkategorijaFromDb = PotkategorijaRepository.GetById(id);

            if (potkategorijaFromDb == null)
                return NotFound();

            try
            {
                PotkategorijaRepository.DeletePotkategorija(id);
                return Ok("Potkategorija je obrisana");

            }
            catch (System.Exception)
            {
                return BadRequest("Potkategorija nije obrisan");
            }

        }
    }
}