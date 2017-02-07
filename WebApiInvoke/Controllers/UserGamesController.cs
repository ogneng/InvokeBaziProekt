using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiInvoke.Models;


namespace WebApiInvoke.Controllers
{
    public class UserGamesController : ApiController
    {
        // GET: api/UserGames
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserGames/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserGames
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserGames/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserGames/5
        public void Delete(int id)
        {
        }
    }
}
