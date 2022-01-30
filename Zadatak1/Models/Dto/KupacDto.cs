using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zadatak1.Models.Dto
{
    public class KupacDto
    {
        public int IDKupac { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(10, ErrorMessage = "Maksimalna duljina imena je 10 znakova")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; }

        [EmailAddress(ErrorMessage = "Neispravna e-mail adresa")]
        public string Email { get; set; }
        
    }

    public class BuyerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}