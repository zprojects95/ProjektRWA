USE AdventureWorksOBP
go

create procedure SelectTop10Desc
as
begin
	select top 10 * from Kupac order by IDKupac desc
end
go

CREATE PROCEDURE GetGradovi
AS
BEGIN
	select * from Grad
END
GO

create procedure GetGrad
	@IDGrad int
as
begin
	select * from Grad where IDGrad = @IDGrad
end
go


CREATE PROCEDURE GetKupac
	@id int
AS
BEGIN
	select * from Kupac where IDKupac=@id
END
GO

CREATE PROCEDURE DeleteKupac
	@id int
AS
BEGIN
	delete from Kupac where IDKupac=@id
END
GO



CREATE PROCEDURE UpdateKupac
	@id int,
	@ime nvarchar(50),
	@prezime nvarchar(50),
	@email nvarchar(50),
	@telefon nvarchar(25),
	@gradID int
AS
BEGIN
	update Kupac set Ime=@ime, Prezime=@prezime, Email=@email, Telefon=@telefon, GradID=@gradID where IDKupac=@id 
END
GO

CREATE PROCEDURE InsertKupac
	@ime nvarchar(50),
	@prezime nvarchar(50),
	@email nvarchar(50),
	@telefon nvarchar(25),
	@gradID int
AS
BEGIN
	insert into Kupac values(@ime, @prezime, @email, @telefon, @gradID)
END
GO