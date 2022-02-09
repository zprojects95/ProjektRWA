using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Zadatak1.Repositories
{
    public static class DrzavaRepository
    {
        public static DataSet ds { get; set; }
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static List<Drzava> GetAll()
        {
            List<Drzava> drzave = new List<Drzava>();

            ds = SqlHelper.ExecuteDataset(cs, "GetDrzave");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                drzave.Add(new Drzava
                {
                    IDDrzava= (int)row["IDDrzava"],
                    Naziv = row["Naziv"].ToString()
                });
            }
            return drzave;
        }
    }
}