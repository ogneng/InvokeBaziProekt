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
    public class WorkshopController : ApiController
    {
        // GET: api/Workshop
        public List<Workshops> Get()
        {
            List<Workshops> pomList = new List<Workshops>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.workshops";

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Workshops works = new Workshops();

                            works.WorkshopID = reader.GetInt64(0);
                            works.WorkshopName = reader.GetString(1);
                            works.GameName = reader.GetString(2);

                            pomList.Add(works);
                        }

                    }
                }
            }
            return pomList;
        }

        // GET: api/Workshop/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Workshop
        public IHttpActionResult Post(Workshops works)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.workshops " +
                                "(workshopsname,gamesname) " +
                           $"VALUES('{works.WorkshopName}','{works.GameName}');";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Added workshop");
            }
        }

        // PUT: api/Workshop/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Workshop/5
        public void Delete(int id)
        {
        }
    }
}
