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
    public class RegisterController : ApiController
    {
        // GET: api/Register
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Register/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Register
        // POST: api/Users
        public IHttpActionResult Post(ItemArtist user)
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


                    //cmd.CommandText = "SELECT * from users where users.usersid = 6 ";
                    //   cmd.CommandText = "SELECT users.usersid from users where users.username = '" + user.UserName + "'; ";

                    cmd.CommandText = $"SELECT * FROM invoke.users where users.username = '{user.UserName}'";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            user.UserID = reader.GetInt64(0);
                          

                        }
                    }


                    if (user.ItemArtisName == "asd123")
                    {
                        cmd.CommandText = "INSERT INTO invoke.costomers " +
                            "(usersid,costomersusername) " +
                            $"VALUES({user.UserID},'{user.UserName}');";
                        cmd.ExecuteNonQuery();

                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO invoke.itemartist " +
                             "(usersid,itemartistusername,itemartistname,itemartistsurname) " +
                             $"VALUES({user.UserID},'{user.UserName}','{user.ItemArtisName}','{user.ItemArtisSurName}') ";

                        cmd.ExecuteNonQuery();
                    }

                    

                   
                }
                return Ok("Added user");
            }
        }

        // PUT: api/Register/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Register/5
        public void Delete(int id)
        {
        }
    }
}
