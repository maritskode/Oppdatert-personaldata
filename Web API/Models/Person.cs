using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAPI.Models
{
    /// <summary>
    /// Representerer en bestemt person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// ID fra SQL databasen.
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// Personens fornavn.
        /// </summary>
        public string Fornavn { get; set; } = "";

        /// <summary>
        /// Personens mellomnavn.
        /// </summary>
        public string Mellomnavn { get; set; } = "";

        /// <summary>
        /// Personens etternavn.
        /// </summary>
        public string Etternavn { get; set; } = "";

        /// <summary>
        /// Personens gateadresse.
        /// </summary>
        public string Adresse { get; set; } = "";

        /// <summary>
        /// Personens postnummer.
        /// </summary>
        public int Postnummer { get; set; } = 0;

        /// <summary>
        /// Personens poststed.
        /// </summary>
        public string Poststed { get; set; } = "";

        /// <summary>
        /// Personens poststed.
        /// </summary>
        public string Email { get; set; } = "";

        /// <summary>
        /// Personens fulle informasjon.
        /// </summary>
        public string getFullInfo
        {
            get
            {
                string fullInfoString = "";
                if (Adresse == null && Email != null)
                {
                    fullInfoString = $"{ Fornavn } { Mellomnavn } { Etternavn }, ({ Email })";
                }
                if (Adresse == null && Email == null)
                {
                    fullInfoString = $"{ Fornavn } { Mellomnavn } { Etternavn }";
                }
                //Beate Knutsen, Tirilveien 5, 5263 Hamar (beate.knutsen@gmail.com)
                if (Adresse != null && Email != null)
                {
                    fullInfoString = $"{ Fornavn } { Mellomnavn } { Etternavn }, { Adresse }, { Postnummer } { Poststed } ({ Email })";
                }
                if (Adresse != null && Email == null)
                {
                    fullInfoString = $"{ Fornavn } { Mellomnavn } { Etternavn }, { Adresse }, { Postnummer } { Poststed }";
                }
                return fullInfoString;
            }
        }

    }
}