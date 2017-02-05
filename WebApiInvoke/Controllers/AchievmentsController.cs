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
    public class AchievmentsController : ApiController
    {
        // GET: api/Achievments
        public List<Achievements> Get()
        {
            List<Achievements> pomList = new List<Achievements>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.achievements";



                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Achievements achi = new Achievements();
                            achi.IAchievementID = reader.GetInt64(0);
                            achi.UserID = reader.GetInt64(1);
                            achi.AchievementTitle = reader.GetString(2);
                            achi.GameName = reader.GetString(3);

                            pomList.Add(achi);
                        }

                    }
                }
            }
            return pomList;
        }

        // GET: api/Achievments/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Achievments
        public IHttpActionResult Post(Achievements achiev)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.achievements " +
                                "(achievementstitle,gamesname) " +
                           $"VALUES('{achiev.AchievementTitle}','{achiev.GameName}');";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Added achievment");
            }
        }

        // PUT: api/Achievments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Achievments/5
        public void Delete(int id)
        {
        }
    }
}
