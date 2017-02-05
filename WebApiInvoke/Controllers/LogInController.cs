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
    public class LogInController : ApiController
    {
        // GET: api/LogIn
  /*      public List<Users> Get()
        {
            List<Users> UsersList = new List<Users>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"SELECT * FROM invoke.users where users.username = 'Igor'";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users();
                            user.UserID = reader.GetInt64(0);
                            user.UserName = reader.GetString(1);
                            user.Password = reader.GetString(2);
                            user.Email = reader.GetString(3);
                            user.Country = reader.GetString(5);
                            user.Gender = reader.GetString(5);

                            UsersList.Add(user);

                        }

                    }
                }
            }
            return UsersList;
        }
        */
        // GET: api/LogIn/5
        public List<Users> Get(string id)
        {
            List<Users> UsersList = new List<Users>();
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"SELECT * FROM invoke.users where users.username = '{id}'";


                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users();
                            user.UserID = reader.GetInt64(0);
                            user.UserName = reader.GetString(1);
                            user.Password = reader.GetString(2);
                            user.Email = reader.GetString(3);
                            user.Country = reader.GetString(5);
                            user.Gender = reader.GetString(5);

                            UsersList.Add(user);

                        }
                    }

                }
            }

            return UsersList;
        }

        // POST: api/LogIn
        public IHttpActionResult Post(Users user)
        {
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                         cmd.CommandText = "SELECT users.username from invoke.Users "
                        + "WHERE users.username ='" + user.UserName + "' and users.userspassword = '" + user.Password + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return Ok(user);
                        }
                        else
                        {
                            return BadRequest("Wrong User Name or Password");
                        }
                     
                    }
                }
               
            }
        }

        // PUT: api/LogIn/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LogIn/5
        public void Delete(int id)
        {
        }
    }
}
