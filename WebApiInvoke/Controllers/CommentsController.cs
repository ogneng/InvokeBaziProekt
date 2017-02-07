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
    public class CommentsController : ApiController
    {
        // GET: api/Comments
        public List<Comments> Get()
        {
            List<Comments> pomList = new List<Comments>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.comments";

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Comments com = new Comments();
                            com.CommentID = reader.GetInt64(0);
                            com.CommentContent = reader.GetString(1);
                            com.CommentDateTime = (DateTime)reader.GetDateTime(2);
                            com.UserID = reader.GetInt64(3);
                            com.TopicID = reader.GetInt64(4);
                            pomList.Add(com);
                        }

                    }
                }
            }
            return pomList;
        }

        // GET: api/Comments/5
        public List<Comments> Get(string id)
        {
            List<Comments> pomList = new List<Comments>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"SELECT * from invoke.comments  where comments.topicsid = {id}";

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Comments com = new Comments();
                            com.UserID = reader.GetInt64(0);
                            com.CommentContent = reader.GetString(1);
                            com.CommentDateTime = (DateTime)reader.GetDateTime(2);
                            com.UserID = reader.GetInt64(3);
                            com.TopicID = reader.GetInt64(4);
                            pomList.Add(com);
                        }

                    }
                }
            }
            return pomList;
        }

        // POST: api/Comments
        public IHttpActionResult Post(Comments com)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data
                    if (com.Pom == "add") {

                        cmd.CommandText = "INSERT INTO invoke.comments " +
                                    "(commentscontent,commentsdatewithtime,usersid,topicsid) " +
                               $"VALUES('{com.CommentContent}','NOW()','{com.UserID}','{com.TopicID}');";

                        cmd.ExecuteNonQuery();

                    } else if (com.Pom == "edit") {


                        cmd.CommandText = "UPDATE invoke.comments " +
                                 $"SET commentscontent = '{com.newContent}', commentsdatewithtime='NOW()' " +
                                 $"WHERE usersid = {com.UserID} and topicsid = {com.TopicID} and commentscontent = '{com.CommentContent}' ; ";
                        cmd.ExecuteNonQuery();
                        

                    }
                    else if (com.Pom == "delete") {
                        cmd.CommandText = "DELETE FROM invoke.comments " +
                                    $"WHERE usersid = {com.UserID} and topicsid = {com.TopicID} and commentscontent = '{com.CommentContent}' ; ";
                        cmd.ExecuteNonQuery();
                    }
                }

                return Ok("Added comment");
            }
        }

        // PUT: api/Comments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comments/5
        public void Delete(int id)
        {
        }
    }
}
