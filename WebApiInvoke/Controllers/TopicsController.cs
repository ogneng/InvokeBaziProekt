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
    public class TopicsController : ApiController
    {
        // GET: api/Topics
        public List<Topics> Get()
        {
            List<Topics> pomList = new List<Topics>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.topics";

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Topics topic = new Topics();
                            topic.TopicID = reader.GetInt64(0);
                            topic.UserID = reader.GetInt64(1);
                            topic.ForumID = reader.GetInt64(2);
                            topic.TopicName = reader.GetString(3);
                            topic.TopicDescription = reader.GetString(4);
                            topic.TopicDateTime = (DateTime)reader.GetDateTime(5);

                            pomList.Add(topic);
                        }

                    }
                }
            }
            return pomList;
        }

        // GET: api/Topics/5
        public List<Topics> Get(string id)
        {
            List<Topics> pomLista = new List<Topics>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"SELECT * from invoke.topics where topics.usersid = {id}";

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Topics topic = new Topics();
                            topic.TopicID = reader.GetInt64(0);
                            topic.UserID = reader.GetInt64(1);
                            topic.ForumID = reader.GetInt64(2);
                            topic.TopicName = reader.GetString(3);
                            topic.TopicDescription = reader.GetString(4);
                            topic.TopicDateTime = (DateTime)reader.GetDateTime(5);

                            pomLista.Add(topic);
                        }

                    }
                }
            }
            return pomLista;
        }

        // POST: api/Topics
        public IHttpActionResult Post(Topics topic)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.topics " +
                                "(topicsname,topicsdescription,topicsdatewithtime,usersid,forumsid) " +
                           $"VALUES('{topic.TopicName}','{topic.TopicDescription}','NOW()',{topic.UserID},{topic.ForumID});";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Added topic");
            }
        }
        // PUT: api/Topics/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Topics/5
        public void Delete(int id)
        {
        }
    }
}
