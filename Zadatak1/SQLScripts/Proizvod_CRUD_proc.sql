CREATE PROCEDURE [dbo].[GetProizvodi]
AS
BEGIN
	SELECT * FROM Proizvod
END
GO

CREATE PROCEDURE [dbo].[GetProizvod]
	@id int
AS
BEGIN
	select * from Proizvod where IDProizvod=@id
END
GO

CREATE PROCEDURE [dbo].[InsertProizvod]
	@naziv nvarchar(50),
	@brojProizvoda nvarchar(20),
	@boja nvarchar(15),
	@minimalnaKoličina smallint,
	@cijena money,
	@potkategorijaId int
AS
BEGIN
	insert into Proizvod values(@naziv, @brojProizvoda, @boja, @minimalnaKoličina,
	@cijena, @potkategorijaId)
END
GO

CREATE PROCEDURE [dbo].[UpdateProizvod]
	@id int,
	@naziv nvarchar(50),
	@brojProizvoda nvarchar(20),
	@boja nvarchar(15),
	@minimalnaKoličina smallint,
	@cijena money,
	@potkategorijaId int
AS
BEGIN
	update Proizvod set Naziv=@naziv, BrojProizvoda=@brojProizvoda, Boja=@boja,
	MinimalnaKolicinaNaSkladistu=@minimalnaKoličina, CijenaBezPDV=@cijena, 
	PotkategorijaId=@potkategorijaId where IDProizvod=@id 
END
GO

CREATE PROCEDURE [dbo].[DeleteProizvod]
	@id int
AS
BEGIN
	delete from Proizvod where IDProizvod=@id
END
GO