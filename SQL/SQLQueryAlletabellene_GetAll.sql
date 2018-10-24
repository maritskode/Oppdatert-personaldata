-- =============================================
-- Author:      <Author, Marit Irene Sandanger,>
-- Create Date: <Create Date, 24.10.2018, >
-- Description: <Description, Prosedyren returnerer all info fra alle tre tabellene: 
-- dbo.Navnetabell, dbo.Adressetabell, dbo.Emailtabell.,>
-- =============================================

create procedure dbo.Alletabellene_GetAll
as
begin
	set nocount on;

	select PersonalBrukerID, Fornavn, Mellomnavn, Etternavn
	from dbo.Navnetabell;

select Gateadresse, Postnummer, Poststed, NavneID
from dbo.Adressetabell;

select Email, NavneID
 	from dbo.Emailtabell;

end

