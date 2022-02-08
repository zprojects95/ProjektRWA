using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Zadatak1.Models;

namespace Zadatak1.Repositories
{
    public class ProizvodRepository
    {
        public static DataSet ds { get; set; }
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public static IEnumerable<Proizvod> GetAll()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetProizvodi");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new Proizvod
                {
                    IDProizvod = (int)row["IDProizvod"],
                    Naziv = row["Naziv"].ToString(),
                    BrojProizvoda = row["BrojProizvoda"].ToString(),
                    Boja = row["PotkategorijaID"] != DBNull.Value ? row["Boja"].ToString() : "",
                    MinimalnaKolicina = Convert.ToInt16(row["MinimalnaKolicinaNaSkladistu"]),
                    Cijena = (decimal)row["CijenaBezPDV"],
                    PotkategorijaId = row["PotkategorijaID"] != DBNull.Value ? (int)row["PotkategorijaID"] : 1,
                };
            }
        }

        private static Proizvod GetProizvodFromDataRow(DataRow row)
        {
            return new Proizvod
            {
                IDProizvod = (int)row["IDProizvod"],
                Naziv = row["Naziv"].ToString(),
                BrojProizvoda = row["BrojProizvoda"].ToString(),
                Boja = row["PotkategorijaID"] != DBNull.Value ? row["Boja"].ToString() : "",
                MinimalnaKolicina = Convert.ToInt16(row["MinimalnaKolicinaNaSkladistu"]),
                Cijena = (decimal)row["CijenaBezPDV"],
                PotkategorijaId = row["PotkategorijaID"] != DBNull.Value ? (int)row["PotkategorijaID"] : 1,
            };
        }

        public static Proizvod GetById(int id)
        {
            try
            {
                DataRow row = SqlHelper.ExecuteDataset(cs, "GetProizvod", id).Tables[0].Rows[0];
                return GetProizvodFromDataRow(row);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int InsertProizvod(Proizvod proizvod)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertProizvod", proizvod.Naziv, proizvod.BrojProizvoda,
                                             proizvod.Boja, proizvod.MinimalnaKolicina, proizvod.Cijena,
                                             proizvod.PotkategorijaId);
        }

        public static int UpdateProizvod(Proizvod proizvod)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateProizvod", proizvod.IDProizvod, proizvod.Naziv, proizvod.BrojProizvoda,
                                             proizvod.Boja, proizvod.MinimalnaKolicina, proizvod.Cijena,
                                             proizvod.PotkategorijaId);
        }

        public static int DeleteProizvod(int proizvodId)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteProizvod", proizvodId);
        }
    }
}