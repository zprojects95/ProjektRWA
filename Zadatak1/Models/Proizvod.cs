using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadatak1.Models
{
    public class Proizvod
    {
        public int IDProizvod { get; set; }
        public string Naziv { get; set; }
        public string BrojProizvoda { get; set; }
        public string Boja { get; set; }
        public int MinimalnaKolicina { get; set; }
        public decimal Cijena { get; set; }
        public int PotkategorijaId { get; set; }
    }
}