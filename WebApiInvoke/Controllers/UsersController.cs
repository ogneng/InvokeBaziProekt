using Npgsql;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiInvoke.Models;

namespace WebApiInvoke.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public List<Users> Get()
        {
            List<Users> UsersList = new List<Users>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.Users";



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

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public IHttpActionResult Post(Users user)
        {
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data
                    /* *Igor*
                     * if we want to include userid..
                     *    cmd.CommandText = "INSERT INTO invoke.users " +
                                "(userid,username,userspassword,usersemail,userscountry,usersgender) " +
                                $"VALUES('user.UserID = *','{user.UserName}','{user.Password}','{user.Email}','{user.Country}','{user.Gender}');";
                     * because we have nextval('users_usersid_seq'::regclass) in DataBase we dont need to include
                     * userid the DB know that he need to add the sequence
                     */
                    cmd.CommandText = "INSERT INTO invoke.users " +
                                "(username,userspassword,usersemail,userscountry,usersgender) " +
                           $"VALUES('{user.UserName}','{user.Password}','{user.Email}','{user.Country}','{user.Gender}');";

                    cmd.ExecuteNonQuery();
                }
                return Ok("Added user");
            }
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
