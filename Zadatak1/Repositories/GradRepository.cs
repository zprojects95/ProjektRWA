using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Zadatak1.Repositories
{
    public static class GradRepository
    {
        public static DataSet ds { get; set; }
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static List<Grad> GetAll()
        {
            List<Grad> gradovi = new List<Grad>();

            ds = SqlHelper.ExecuteDataset(cs, "GetGradovi");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                gradovi.Add(new Grad
                {
                    IDGrad = (int)row["IDGrad"],
                    Naziv = row["Naziv"].ToString()
                });
            }
            return gradovi;
        }

        public static Grad GetById(int IDGrad)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetGrad", IDGrad).Tables[0].Rows[0];
            return new Grad
            {
                IDGrad = (int)row["IDGrad"],
                DrzavaID = (int)row["DrzavaID"],
                Naziv = row["Naziv"].ToString()
            };
        }
    }
}