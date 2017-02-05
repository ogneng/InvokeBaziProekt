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
    public class AdminsController : ApiController
    {
        // GET: api/Admins
        public List<Admins> Get()
        {
            List<Admins> pomList = new List<Admins>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.admins";



                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Admins admin = new Admins();
                            admin.UserID = reader.GetInt64(0);
                            admin.AdminUserName = reader.GetString(1);
                            admin.AdminName = reader.GetString(2);
                            admin.AdminSurName = reader.GetString(3);
                            admin.Phone = reader.GetInt64(4);
                            pomList.Add(admin);
                        }

                    }
                }
            }
            return pomList;
        }

        // GET: api/Admins/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admins
        public IHttpActionResult Post(Admins admin)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.admins " +
                                "(adminsusername,adminsname,adminssurname,adminsphone) " +
                           $"VALUES('{admin.AdminUserName}','{admin.AdminName}','{admin.AdminSurName}','{admin.Phone}');";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Added admin");
            }
        }

        // PUT: api/Admins/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admins/5
        public void Delete(int id)
        {
        }
    }
}
