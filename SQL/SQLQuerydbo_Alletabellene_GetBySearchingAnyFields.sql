-- =============================================
-- Author:      <Author, Marit Irene Sandanger,>
-- Create Date: <Create Date, 24.10.2018, >
-- Description: <Description, Prosedyren soeker gjennom alle tabellene 
-- dbo.Navnetabell, dbo.Adressetabell, dbo.Emailtabell og returnerer alle 
-- kolonnene der et av feltene er identisk med @AnyField innparameteren. 
-- @AnyField innparameteren skal kunne være lik som Fornavn, Mellomnavn, 
-- Etternavn, Gateadresse, Postnummer, Poststed, eller Email.,>
-- =============================================

create procedure dbo.Alletabellene_GetBySearchingAnyFields
	@AnyField nvarchar(50)
as
begin
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    set nocount on;

	select PersonalBrukerID, Fornavn, Mellomnavn, Etternavn
	from dbo.Navnetabell
	where (Fornavn = @AnyField or Mellomnavn = @AnyField or Etternavn = @AnyField)

	select Gateadresse, Postnummer, Poststed, NavneID
	from dbo.Adressetabell
	where (Gateadresse = @AnyField or Postnummer = @AnyField or Poststed = @AnyField or NavneID = @AnyField)

	select Email, NavneID
	from dbo.Emailtabell
	where (Email = @AnyField or NavneID = @AnyField)

end
