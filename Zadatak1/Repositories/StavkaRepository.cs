using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Zadatak1.Models;

namespace Zadatak1.Repositories
{
    public class StavkaRepository
    {
        public static DataSet ds { get; set; }
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static List<Stavka> GetStavkeByRacunId(int id)
        {
            List<Stavka> stavke = new List<Stavka>();

            ds = SqlHelper.ExecuteDataset(cs, "GetStavkeRacuna", id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                stavke.Add(new Stavka
                {
                    BrojKreditneKartice = row["Broj Kreditne Kartice"].ToString(),
                    Komercijalist = row["Komercijalist"].ToString(),
                    Proizvod = row["Proizvod"].ToString(),
                    Potkategorija = row["Potkategorija"].ToString(),
                    Kategorija = row["Kategorija"].ToString()
                });
            }
            return stavke;
        }
    }
}