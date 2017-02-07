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
    public class SetGameController : ApiController
    {

        public List<Game> Get()
        {
            //List<string> lista = new List<string>();
            List<Game> lista = new List<Game>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                //so using kak sto e tuka konekcijata sama se zatvara
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.Games";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Game game = new Game();
                            game.Name = reader.GetString(0);
                            game.Description = reader.GetString(1);
                            game.Price = reader.GetInt32(2);
                            game.Date = (DateTime)reader.GetDate(3);
                            game.Developer = reader.GetString(4);
                            game.Genre = reader.GetString(5);

                            lista.Add(game);

                        }

                    }
                }
            }
            return lista;
        }


        public List<Game> Get(string id)
        {
            List<Game> gamesLike = new List<Game>();
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Retrieve all rows
                    cmd.CommandText = $"SELECT * FROM invoke.games WHERE UPPER(gamesname) like UPPER('%{id}%')";


                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Game game = new Game();
                            game.Name = reader.GetString(0);
                            game.Description = reader.GetString(1);
                            game.Price = reader.GetInt32(2);
                            game.Date = (DateTime)reader.GetDate(3);
                            game.Developer = reader.GetString(4);
                            game.Genre = reader.GetString(5);

                            gamesLike.Add(game);

                        }
                    }

                }
            }

            return gamesLike;
        }

      

        public IHttpActionResult Post(Game igra)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.games " +
                                "(gamesname,gamesdescription,gamesprice,gamesreleasedate,gamesdeveloper,gamesgenre) " +
                           $"VALUES('{igra.Name}','{igra.Description}',{igra.Price},'{igra.Date}','{igra.Developer}','{igra.Genre}');";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Added game");
            }
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Games/gamesname
        public IHttpActionResult Delete(Game igra)
        {
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data
                    cmd.CommandText = "DELETE FROM  invoke.games " +
                                "WHERE gamesname = ''" +
                           $"VALUES('{igra.Name}');";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Deletetd game");
            }
        }
    }
}
