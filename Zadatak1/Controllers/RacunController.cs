using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Zadatak1.Repositories;

namespace Zadatak1.Controllers
{
    public class RacunController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetByKupacId(int id)
        {
            return Ok(RacunRepository.GetByKupacId(id));
        }
    }
}