USE [AdventureWorksOBP]
GO
/****** Object:  StoredProcedure [dbo].[GetStavkeRacuna]    Script Date: 2/5/2022 11:44:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetStavkeRacuna] @id int
AS
SELECT KreditnaKartica.Broj AS 'Broj Kreditne Kartice',
	   CONCAT(Komercijalist.Ime, ' ', Komercijalist.Prezime) AS 'Komercijalist',
	   Proizvod.Naziv AS 'Proizvod',
	   Potkategorija.Naziv AS 'Potkategorija',
	   Kategorija.Naziv AS 'Kategorija'
FROM Racun
INNER JOIN KreditnaKartica ON Racun.KreditnaKarticaID = KreditnaKartica.IDKreditnaKartica
INNER JOIN Komercijalist ON Racun.KomercijalistID = IDKomercijalist
INNER JOIN Stavka ON  Stavka.RacunID = Racun.IDRacun
INNER JOIN Proizvod ON  Stavka.ProizvodID = Proizvod.IDProizvod
INNER JOIN Potkategorija ON  Proizvod.PotkategorijaID = Potkategorija.IDPotkategorija
INNER JOIN Kategorija ON  Potkategorija.KategorijaID= Kategorija.IDKategorija
WHERE Racun.IDRacun = @id;