using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadatak1.Models
{
    public class Potkategorija
    {
        public int IDPotkategorija { get; set; }
        public string Naziv { get; set; }

        public int KategorijaId { get; set; }
    }
}