# Oppdatert-personaldata
Prosjektet skal administrere en database med personal og brukerinformasjon. 

Den oppdaterte utgaven av personaldata er sortert i 3 hovedkataloger: "SQL", "Web API" og "MVVM". Under disse tre katalogene finner vi de tilhørende datafilene. 

# SQL
Under katalogen "SQL" finner du 4 lagrede prosedyrer og et Excel-regneark med to ark som gir oversikt over tabellene som ligger inne i databasen. Tabellene som ligger inne i databasen er nærmere forklart under Wiki-siden:
https://github.com/maritskode/Oppdatert-personaldata/wiki/Tabellstruktur-under-SQL-databasen-%22personliste%22

# Web API
Under katalogen "Web API" finner du en rekke klasser som styrer Web API. Når jeg opprettet Visual Studio prosjektet, laget jeg et ASP.NET Web Application (.NET Framework) prosjekt og valgte deretter WeB API og det fulgte med mange default kataloger og metoder. Disse default katalogene og metodene er ikke gjengitt her.   
Mer detaljert forklaring finner du under Wiki-siden:
https://github.com/maritskode/Oppdatert-personaldata/wiki/Web-API-struktur-og-forel%C3%B8pige-resultater

WeB API koden benytter seg av Dapper for å knytte seg til SQL serveren. Trenger du å installere Dapper? Følg disse stegene: Åpne Visual Studio, høyreklikk på "References" i "Solution Explorer" vinduet og velg "Manage NuGet Packages". Merker området "Browse" og fyll ut søkefeltet med "Dapper". Velg "Dapper by Sam Saffron, Marc Gravell, Nick Craver, (...)" og trykk "Install" knappen. 

Den direkte tilkoblingen til SQL serveren foregår via connectionString - for mer informasjon om ulike connectionStrings, se nettsiden: https://www.connectionstrings.com/sql-server/

# MVVM
MVVM koden benytter seg av pakken Caliburn.Micro. Trenger du å installere Caliburn.Micro? Samme prosedyre som ved å installere Dapper, men søk etter Caliburn Micro. Denne pakken vil skape koblinger mellom de ulike Models - Views - ViewModels som gjør det mye enklere å programmer MVVM.

Mer detaljert forklaring, inkludert skjermbilder av det grafiske grensesnittet finner du under Wiki-siden:
https://github.com/maritskode/Oppdatert-personaldata/wiki/MVVM-strukturen

# REST klient
REST klient koden genererer et grafisk brukergrensesnitt som kobler mot en hvilken som helst Web API. Denne koden er mitt første forsøk på å lage en REST klient. Kunnskap fra denne koden kan brukes for å skape kobling mellom MVVM og Web API. Foreløpig inneholder denne katalogen et eksempel. Se mer informasjon og skjermbilde av dette grensesnittet hvor den benyttes mot dette prosjektets Web API.

# Status
Torsdag 25.oktober kl 15:30
1) Har opprettet en REST klient som kan koble seg til Web API og hente ut navnene til personene i databasen "personliste". Men klienten er bare et enkelt brukergrensesnitt og ikke en integrert del av MVVM. Målet er å få REST klienten til å bli en integrert del av MVVM koden. 

Torsdag 25.oktober kl 11:00
1) Koblingen mellom SQL databasen og Web API fungerer med GET protokollen slik at vi får ut en oversikt over fornavn, mellomnavn og etternavn i JSON format inne i POSTMAN. Dette er dokumentert i Wiki (https://github.com/maritskode/Oppdatert-personaldata/wiki/Web-API-struktur-og-forel%C3%B8pige-resultater).
2) Jobber videre med å få minst en egenskap, f.eks. "fornavn" videre fra Web API og frem til MVVM grensesnittet. 
