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
    public class ItemsController : ApiController
    {
        // GET: api/Items
        public List<Items> Get()
        {
            List<Items> ItemList = new List<Items>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.Items";



                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Items item = new Items();
                            item.ItemID = reader.GetInt64(0);
                            item.ItemName = reader.GetString(1);
                            item.ItemType = reader.GetString(2);
                            item.ItemDescription = reader.GetString(3);
                            item.ItemPrice = reader.GetInt32(4);
                            item.GameName = reader.GetString(5);
                            item.UserID = reader.GetInt64(6);
                            item.ItemArtistUserName = reader.GetString(7);
                            item.WorkShopID = reader.GetInt64(8);

                            ItemList.Add(item);
                        }

                    }
                }
            }
            return ItemList;
        }

        // GET: api/Items/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Items
        public IHttpActionResult Post(Items item)
        {
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.items " +
                                "(itemsname,itemstype,itemsdescription,itemsprice,gamesname,usersid,itemartistusername,workshopsid) " +
                           $"VALUES('{item.ItemName}','{item.ItemType}','{item.ItemDescription}',{item.ItemPrice},'{item.GameName}',{item.UserID},'{item.ItemArtistUserName}',{item.WorkShopID});";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Added forum");
            }
        }

        // PUT: api/Items/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Items/5
        public void Delete(int id)
        {
        }
    }
}
