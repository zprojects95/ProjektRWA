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
    public class KategorijaRepository
    {
        public static DataSet ds { get; set; }
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public static IEnumerable<Kategorija> GetAll()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetKategorije");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new Kategorija
                {
                    IDKategorija = (int)row["IDKategorija"],
                    Naziv = row["Naziv"].ToString()
                };
            }
        }

        private static Kategorija GetKategorijaFromDataRow(DataRow row)
        {
            return new Kategorija
            {
                IDKategorija = (int)row["IDKategorija"],
                Naziv = row["Naziv"].ToString()
            };
        }

        public static Kategorija GetById(int id)
        {
            try
            {
                DataRow row = SqlHelper.ExecuteDataset(cs, "GetKategorija", id).Tables[0].Rows[0];
                return GetKategorijaFromDataRow(row);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int InsertKategorija(Kategorija kategorija)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertProizvod", kategorija.Naziv);
        }

        public static int UpdateKategorija(Kategorija kategorija)
        {
            return SqlHelper.ExecuteNonQuery(cs, "Updatekategorija", kategorija.Naziv);
        }

        public static int DeleteKategorija(int kategorijaId)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteKategorija", kategorijaId);
        }
    }
}