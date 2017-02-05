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
    public class SetsGamesController : ApiController
    {
        // GET: api/SetsGames
        public List<SetsGames> Get()
        {
            List<SetsGames> pomList = new List<SetsGames>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.setsgames";

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            SetsGames sets = new SetsGames();
                            sets.SetGameID = reader.GetInt64(0);
                            sets.UserID = reader.GetInt64(1);
                            sets.AdminUsername = reader.GetString(2);
                            sets.GameName = reader.GetString(3);
                            sets.SetGameDate = (DateTime)reader.GetDateTime(4);                            

                            pomList.Add(sets);
                        }

                    }
                }
            }
            return pomList;
        }

        // GET: api/SetsGames/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SetsGames
        public IHttpActionResult Post(SetsGames sgames)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.creditcards " +
                                "(adminsusername,gamesname,setgamesdate) " +
                           $"VALUES('{sgames.AdminUsername}','{sgames.GameName}','{sgames.SetGameDate}');";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Added setgame");
            }
        }

        // PUT: api/SetsGames/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SetsGames/5
        public void Delete(int id)
        {
        }
    }
}
