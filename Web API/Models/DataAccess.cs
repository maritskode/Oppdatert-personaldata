using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MyFirstAPI.Models
{
    public class DataAccess
    {
        public void InsertPerson(string fornavn, string mellomnavn, string etternavn, string adresse, int postnummerInt, string poststed, string email, int ID)
        {
            //Bruker using-statement for at forbindelsen skal bli brutt etterpå. Her har vi kall mot lagrede funksjoner som ligger inn i SQL databasen vår.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("PersonlisteDB")))
            {
                List<Person> people = new List<Person>();

                //Den korte varianten.
                //Person newPerson = new Person { Fornavn = fornavn, Mellomnavn = mellomnavn, Etternavn = etternavn, Adresse = adresse, Postnummer = postnummerInt, Poststed = poststed, Email = email };

                //Den litt mer oversiktlige måten. Grei når man skal forlenge listen under vedlikehold..
                Person newPerson = new Person();
                newPerson.ID = ID;
                newPerson.Fornavn = fornavn;
                newPerson.Mellomnavn = mellomnavn;
                newPerson.Etternavn = etternavn;
                newPerson.Adresse = adresse;
                newPerson.Postnummer = postnummerInt;
                newPerson.Poststed = poststed;
                newPerson.Email = email;

                people.Add(newPerson);

                //Gjør et kall til "Stored Procedure" inne i databasen. Prosedyren/funksjonen heter "dbo.Navnetabell_InsertPerson" og
                //den tar inn hele raden med innparameter fra "people"-listen med "Person"-objekter. 
                connection.Execute("dbo.Navnetabell_InsertPerson @Fornavn, @Mellomnavn, @Etternavn, @PBID", people);
            }
        }

        public List<Person> GetAllInfo()
        {
            //Bruker using-statement for at forbindelsen skal bli brutt etterpå. Innenfor "using {} har vi direkte kontakt med databasen "PersonlisteDB".
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("PersonlisteDB")))
            {
                //Her har vi kall mot den lagrede funksjonen dbo.Alletabellene_GetAll som ligger inn i SQL databasen vår
                var output = connection.Query<Person>("dbo.Alletabellene_GetAll").ToList();
                return output;
            }
        }

        //Funksjonen GetPersonList tar imot en tekststreng som inneholder enten fornavn, mellomnavn, etternavn, adresse, postnummer, osv,
        //og returnerer en liste med Person som alle inneholder denne tekststrengen i ett av feltene sine. Merk at også postnummer, som egentlig består av 4 siffer, 
        //sendes gjennom her som en tekst-streng. (NB: Sjekk om postnummer "0032" f.ekse ender opp som 32 på grunn av konvertering mellom int-string-int!!)
        public List<Person> GetPersonList(string anyField)
        {
            //Bruker using-statement for at forbindelsen skal bli brutt etterpå. Innenfor "using {} har vi direkte kontakt med databasen "PersonlisteDB".
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("PersonlisteDB")))
            {
                //AnyField er en tekststreng men kan bestå av et postnummer. I SQL-tabellen vår er postnummeret et "Integer" og ikke "String".'
                //Hvis brukeren har søkt på postnummer, må vi gjøre om fra string til int.
                int postnumber = 0;
                try { postnumber = int.Parse(anyField); }
                catch { }

                //Hvis postnummer er blitt søkt etter:
                if (postnumber >= 999)
                {
                    //Overgang fra string til int gikk bra - bruker har søkt på postnummer. 
                    //Her har vi kall mot lagrede funksjoner som ligger inn i SQL databasen vår.
                    //Koden "new {Postnumber = postnumber}" er en dynamisk tilnærming der man oppretter en ny klasse "Postnumber" som tar inn postnumber
                    //som er innparameter til "GetByPostnumber". Dapper vil putte det som kommer ut av "new {Postnumber = postnumber}", inn i @Postnumber.
                    var output = connection.Query<Person>("dbo.Adressetabell_GetByPostnumber @Postnumber", new { Postnumber = postnumber }).ToList();
                    return output;
                }

                //ellers, et annet felt enn postnummer har blitt søkt etter.
                else
                {
                    //Her har vi kall mot lagrede funksjoner som ligger inn i SQL databasen vår.
                    //Koden "new {AnyField = anyField}" er en dynamisk tilnærming der man oppretter en ny klasse "AnyField" som tar inn anyField
                    //som er innparameter til "GetBySearchingAnyFields". Dapper vil putte det som kommer ut av "new {AnyField = anyField}", inn i @AnyField.
                    var output = connection.Query<Person>("dbo.Alletabellene_GetBySearchingAnyFields @AnyField", new { AnyField = anyField }).ToList();
                    return output;
                }
            }
        }

    }
}