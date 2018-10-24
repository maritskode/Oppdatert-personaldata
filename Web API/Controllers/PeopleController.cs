using MyFirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstAPI.Controllers
{
    /// <summary>
    /// Dette er hvor all informasjonen om personene håndteres.
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        /// <summary>
        /// Gir ut en liste med alle personene vi har i databasen.
        /// </summary>
        /// <returns></returns>
        // GET: api/People
        public List<Person> Get()
        {
            DataAccess db = new DataAccess();

            people = db.GetAllInfo();

            return people;
        }

        // GET: api/People/5
        public List<Person> Get(string searchword)
        {
            DataAccess db = new DataAccess();

            people = db.GetPersonList(searchword);

            return people;
        }

        // POST: api/People
        public void Post([FromBody]string value)
        {
            //DataAccess db = new DataAccess();

            //db.InsertPerson(string fornavn, string mellomnavn, string etternavn, string adresse, int postnummerInt, string poststed, string email, int ID)
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
