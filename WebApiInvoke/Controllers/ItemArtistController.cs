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
    public class ItemArtistController : ApiController
    {
        // GET: api/ItemArtist
        public List<ItemArtist> Get()
        {
            List<ItemArtist> pomList = new List<ItemArtist>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.itemartist";



                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            ItemArtist artist = new ItemArtist();
                            artist.UserID = reader.GetInt64(0);
                            artist.UserName = reader.GetString(1);
                            artist.ItemArtisName = reader.GetString(2);
                            artist.ItemArtisSurName = reader.GetString(3);
                            pomList.Add(artist);
                        }

                    }
                }
            }
            return pomList;
        }

        // GET: api/ItemArtist/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ItemArtist
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ItemArtist/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ItemArtist/5
        public void Delete(int id)
        {
        }
    }
}
