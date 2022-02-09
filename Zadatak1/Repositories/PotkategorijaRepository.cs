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
    public class PotkategorijaRepository
    {
        public static DataSet ds { get; set; }
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public static IEnumerable<Potkategorija> GetAll()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetPotkategorije");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new Potkategorija
                {
                    IDPotkategorija = (int)row["IDPotkategorija"],
                    Naziv = row["Naziv"].ToString(),
                    KategorijaId = row["KategorijaID"] != DBNull.Value ? (int)row["KategorijaID"] : 1
                };

            }
        }

        private static Potkategorija GetPotkategorijaFromDataRow(DataRow row)
        {
            return new Potkategorija
            {
                IDPotkategorija = (int)row["IDPotkategorija"],
                Naziv = row["Naziv"].ToString(),
                KategorijaId = row["KategorijaID"] != DBNull.Value ? (int)row["KategorijaID"] : 1
            };
        }

        public static Potkategorija GetById(int id)
        {
            try
            {
                DataRow row = SqlHelper.ExecuteDataset(cs, "GetPotkategorija", id).Tables[0].Rows[0];
                return GetPotkategorijaFromDataRow(row);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int InsertPotkategorija(Potkategorija potkategorija)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertPotkategorija",  potkategorija.KategorijaId, potkategorija.Naziv);
        }

        public static int UpdatePotkategorija(Potkategorija potkategorija)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdatePotkategorija", potkategorija.IDPotkategorija, potkategorija.Naziv, potkategorija.KategorijaId);
        }

        public static int DeletePotkategorija(int potkategorijaId)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeletePotkategorija", potkategorijaId);
        }
    }
}