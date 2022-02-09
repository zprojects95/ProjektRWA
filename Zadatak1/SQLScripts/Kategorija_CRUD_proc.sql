CREATE PROCEDURE [dbo].[GetKategorije]
AS
BEGIN
	SELECT * FROM Kategorija
END
GO

CREATE PROCEDURE [dbo].[GetKategorija]
	@id int
AS
BEGIN
	select * from Kategorija where IDKategorija=@id
END
GO

CREATE PROCEDURE [dbo].[InsertKategorija]
	@naziv nvarchar(50)
AS
BEGIN
	insert into Kategorija values(@naziv)
END
GO

CREATE PROCEDURE [dbo].[UpdateKategorija]
	@id int,
	@naziv nvarchar(50)
AS
BEGIN
	update Kategorija set Naziv=@naziv where IDKategorija=@id 
END
GO

CREATE PROCEDURE [dbo].[DeleteKategorija]
	@id int
AS
BEGIN
	delete from Kategorija where IDKategorija=@id
END
GO