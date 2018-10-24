-- =============================================
-- Author:      <Author, Marit Irene Sandanger,>
-- Create Date: <Create Date, 24.10.2018, >
-- Description: <Description, Denne prosedyren soeker 
-- gjennom tabellen dbo.Adressetabell og returnerer alle kolonnene tilhørende  
-- dette Postnummeret som er lik innparameteren @Postnumber
-- =============================================

create procedure dbo.Adressetabell_GetByPostnumber
	@Postnumber int
as
begin
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    set nocount on;

	select NavnID, Gateadresse, Postnummer, Poststed
	from dbo.Adressetabell
	where (Postnummer = @Postnumber)
end
