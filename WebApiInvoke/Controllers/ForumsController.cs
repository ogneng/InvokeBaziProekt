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
    public class ForumsController : ApiController
    {
        // GET: api/Forums
        public List<Forums> Get()
        {
            List<Forums> ForumsList = new List<Forums>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.Forums";



                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Forums forum = new Forums();
                            forum.ForumID = reader.GetInt64(0);
                            forum.ForumName = reader.GetString(1);
                            forum.ForumDateTime = (DateTime)reader.GetDateTime(2);
                            forum.GameName = reader.GetString(3);


                            ForumsList.Add(forum);
                        }

                    }
                }
            }
            return ForumsList;
        }

        // GET: api/Forums/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Forums
        public IHttpActionResult Post(Forums forum)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.forums " +
                                "(forumsname,forumsdatewithtime,gamesname) " +
                           $"VALUES('{forum.ForumName}','NOW()','{forum.GameName}');";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Added forum");
            }
        }

        // PUT: api/Forums/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Forums/5
        public void Delete(int id)
        {
        }
    }
}
