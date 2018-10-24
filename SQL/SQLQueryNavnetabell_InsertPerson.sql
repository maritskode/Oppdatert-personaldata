-- =============================================
-- Author:      <Author, Marit Irene Sandanger,>
-- Create Date: <Create Date, 24.10.2018, >
-- Description: <Description, Denne prosedyren legger inn alle navne-variablerne
-- inn i tabellen dbo.Navnetabell, >
-- =============================================

create procedure dbo.Navnetabell_InsertPerson
	@FirstName nvarchar(50), @SecondName nvarchar(50) = '', @Lastname nvarchar(50), @PBID int = ''
as
begin
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    set nocount on;

	insert into dbo.Navnetabell (Fornavn, Mellomnavn, Etternavn, PersonalBrukerID)
	select @FirstName, @SecondName, @Lastname, @PBID
end
