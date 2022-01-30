using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class Kupac
{
    public int IDKupac { get; set; }

    [Required(ErrorMessage = "Ime je obavezno")]
    [StringLength(10, ErrorMessage = "Maksimalna duljina imena je 10 znakova")]
    public string Ime { get; set; }

    [Required(ErrorMessage = "Prezime je obavezno")]
    public string Prezime { get; set; }

    [EmailAddress(ErrorMessage = "Neispravna e-mail adresa")]
    public string Email { get; set; }
    public string Telefon { get; set; }

    [Display(Name = "Grad")]
    [Required(ErrorMessage = "Niste odabrali grad")]
    public int GradID { get; set; }

    public string PunoIme
    {
        get { return $"{Ime} {Prezime}"; }
    }

    public override string ToString()
    {
        return $"{Ime} {Prezime}";
    }
}
