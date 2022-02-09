CREATE PROCEDURE [dbo].[GetPotkategorije]
AS
BEGIN
	SELECT * FROM Potkategorija
END
GO

CREATE PROCEDURE [dbo].[GetPotkategorija]
	@id int
AS
BEGIN
	select * from Potkategorija where IDPotkategorija=@id
END
GO

CREATE PROCEDURE [dbo].[InsertPotkategorija]
	@kategorijaId int,
	@naziv nvarchar(50)
AS
BEGIN
	insert into Potkategorija values(@kategorijaId, @naziv)
END
GO

CREATE PROCEDURE [dbo].[UpdatePotkategorija]
	@id int,
	@naziv nvarchar(50),
	@kategorijaId int
AS
BEGIN
	update Potkategorija set Naziv=@naziv, KategorijaID=@kategorijaId where IDPotkategorija=@id 
END
GO

CREATE PROCEDURE [dbo].[DeletePotkategorija]
	@id int
AS
BEGIN
	delete from Potkategorija where IDPotkategorija=@id
END
GO