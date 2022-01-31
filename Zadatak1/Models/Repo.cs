using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

public class Repo
{
    public static DataSet ds { get; set; }
    private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

    public static Kupac GetKupac(int IDKupac)
    {
        try
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKupac", IDKupac).Tables[0].Rows[0];
            return GetKupacFromDataRow(row);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    private static Kupac GetKupacFromDataRow(DataRow row)
    {
        return new Kupac
        {
            IDKupac = (int)row["IDKupac"],
            Ime = row["Ime"].ToString(),
            Prezime = row["Prezime"].ToString(),
            Email = row["Email"].ToString(),
            Telefon = row["Telefon"].ToString(),
            GradID = row["GradID"] != DBNull.Value ? (int)row["GradID"] : 1
        };
    }

    public static IEnumerable<Kupac> GetKupci()
    {
        ds = SqlHelper.ExecuteDataset(cs, "SelectTop25Desc");
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            yield return new Kupac
            {
                IDKupac = (int)row["IDKupac"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                Email = row["Email"].ToString(),
                Telefon = row["Telefon"].ToString(),
                GradID = row["GradID"] != DBNull.Value ? (int)row["GradID"] : 1
            };
        }
    }

    public static int UpdateKupac(Kupac kupac)
    {
        return SqlHelper.ExecuteNonQuery(cs, "UpdateKupac", kupac.IDKupac, kupac.Ime, kupac.Prezime, kupac.Email, kupac.Telefon, kupac.GradID);
    }

    public static int InsertKupac(Kupac kupac)
    {
        return SqlHelper.ExecuteNonQuery(cs, "InsertKupac", kupac.Ime, kupac.Prezime, kupac.Email, kupac.Telefon, kupac.GradID);
    }
    public static int DeleteKupac(int kupacId)
    {
        return SqlHelper.ExecuteNonQuery(cs, "DeleteKupac", kupacId);
    }
}
