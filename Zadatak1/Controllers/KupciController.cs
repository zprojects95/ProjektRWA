using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Zadatak1.App_Start;
using Zadatak1.Models.Dto;
using Zadatak1.Repositories;

namespace Zadatak1.Controllers
{
    public class KupciController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetKupci()
        {
            int gradId = 1;

            foreach (var parameter in Request.GetQueryNameValuePairs())
            {
                if (parameter.Key == "gradId") gradId = Int32.Parse(parameter.Value);
                else break;
            }

            return Ok(AutoMapperConfig
                .Mapper
                .Map<IEnumerable<KupacDto>>(KupacRepository.GetKupciByCity(gradId)));
        }

        [HttpGet]
        public IHttpActionResult GetKupac(int id)
        {
            var kupacFromDb = Repo.GetKupac(id);

            if (kupacFromDb == null)
                return NotFound();

            return Ok(AutoMapperConfig.Mapper.Map<BuyerDto>(kupacFromDb));
        }

        [HttpPost]
        public IHttpActionResult CreateKupac([FromBody] Kupac kupac)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Repo.InsertKupac(kupac);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateKupac(int id, [FromBody] Kupac kupac)
        {
            var kupacFromDb = Repo.GetKupac(id);

            if (kupacFromDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            Repo.UpdateKupac(kupac);

            return Ok("Kupac ažuriran");
        }

        [HttpDelete]
        public IHttpActionResult DeleteKupac(int id)
        {
            var kupac = Repo.GetKupac(id);

            if (kupac == null)
                return NotFound();

            try
            {
                Repo.DeleteKupac(id);
                return Ok("Kupac obrisan");

            }
            catch (System.Exception)
            {
                return BadRequest("Kupac nije obrisan");
            }

        }
    }
}
