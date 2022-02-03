using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Zadatak1.Repositories
{
    public class RacunRepository
    {
        public static DataSet ds { get; set; }
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static List<Racun> GetByKupacId(int id)
        {
            List<Racun> racuni = new List<Racun>();

            ds = SqlHelper.ExecuteDataset(cs, "GetRacuniKupca", id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                DateTime date = DateTime.Parse(row["DatumIzdavanja"].ToString());

                racuni.Add(new Racun
                {
                    IDRacun = (int)row["IDRacun"],
                    DatumIzdavanja = date,
                    BrojRacuna = row["BrojRacuna"].ToString(),
                    Komentar = row["Komentar"].ToString()
                });
            }
            return racuni;
        }
    }
}