using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Zadatak1.Repositories;

namespace Zadatak1.Controllers
{
    public class DrzavaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(DrzavaRepository.GetAll());
        }
    }
}