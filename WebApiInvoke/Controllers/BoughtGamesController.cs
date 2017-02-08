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
    public class BoughtGamesController : ApiController
    {
        // GET: api/BoughtGames
        public List<BoughtGames> Get()
        {
            List<BoughtGames> pomList = new List<BoughtGames>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.boughtgames";



                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            BoughtGames bgames = new BoughtGames();
                            bgames.BoughtGameID = reader.GetInt64(0);
                            bgames.UserID = reader.GetInt64(1);
                            bgames.GameName = reader.GetString(2);

                            pomList.Add(bgames);
                        }

                    }
                }
            }
            return pomList;
        }

        // GET: api/BoughtGames/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BoughtGames
        public IHttpActionResult Post(Game igra)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.boughtgames " +
                                       "(usersid, gamesname) " +
                                        $"VALUES('{igra.Pom}','{igra.Name}');";
                    cmd.ExecuteNonQuery();
                }

                return Ok("Added game");
            }
        }

        // PUT: api/BoughtGames/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BoughtGames/5
        public void Delete(int id)
        {
        }
    }
}
