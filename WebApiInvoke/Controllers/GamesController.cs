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
    public class GamesController : ApiController
    {
       //static SshClient client;
       //public GamesController()
       // {
       //     if (client == null || !client.IsConnected)
       //     {
       //         client = new SshClient("194.149.136.118", 22, "tunnelvezhbi", "tuneliranje!");
       //         client.Connect();

       //         var port = new ForwardedPortLocal("localhost", 5555, "localhost", 5432); //ova trebase obratno da bidat i dr porta ne e vazno koja porta. da se vnimava da ne e start localhost baza i tamu baza na ista porta
       //         client.AddForwardedPort(port);

       //         port.Start();

       //     }
       //           //  port.Stop();
       //        // client.Disconnect();
            
       // }
        // GET: api/Games
        //public List<Game> Get()
        //{
        //    //List<string> lista = new List<string>();
        //    List<Game> lista = new List<Game>();

        //    using (var client = new SshClient("194.149.136.118", 22, "tunnelvezhbi", "tuneliranje!"))
        //    {
        //        client.Connect();

        //        var port = new ForwardedPortLocal("localhost", 5555, "localhost", 5432); //ova trebase obratno da bidat i dr porta ne e vazno koja porta. da se vnimava da ne e start localhost baza i tamu baza na ista porta
        //        client.AddForwardedPort(port);

        //        port.Start();

        //        using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
        //        {
        //            conn.Open();

        //            using (var cmd = new NpgsqlCommand())
        //            {
        //                cmd.Connection = conn;
        //                cmd.CommandText = "SELECT * from Games";

        //                using (var reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        Game game = new Game();
        //                        game.Name = reader.GetString(0);
        //                        game.Description = reader.GetString(1);
        //                        game.Price = reader.GetInt32(2);
        //                        game.Date = (DateTime)reader.GetDate(3);
        //                        game.Developer = reader.GetString(4);
        //                        game.Genre = reader.GetString(5);

        //                        lista.Add(game);

        //                    }

        //                }
        //            }
        //        }

        //        port.Stop();
        //        client.Disconnect();
        //        return lista;
        //    }
        //}


        //host = localhost; port = 5432; username = db_201617z_va_proekt_invoke_mk_owner; password = invoke_finki; database = db_201617z_va_proekt_invoke_mk
        // server = 127.0.0.1; port = 5432; database = mydatabase; user id = myusername;
        // password = mypassword;

        //    list<game> lista = new list<game>();

        //    using (var conn = new npgsqlconnection("host = localhost; port = 5432; username = postgres; database = invoketest;"))
        //    {
        //        conn.open();
        //        using (var cmd = new npgsqlcommand())
        //        {
        //            cmd.connection = conn;

        //            // retrieve all rows
        //            cmd.commandtext = "select * from invoke.games";


        //            using (var reader = cmd.executereader())
        //            {
        //                while (reader.read())
        //                {
        //                    game game = new game();
        //                    game.name = reader.getstring(0);
        //                    game.description = reader.getstring(1);
        //                    game.price = reader.getint32(2);
        //                    game.date = (datetime)reader.getdate(3);
        //                    game.developer = reader.getstring(4);
        //                    game.genre = reader.getstring(5);

        //                    lista.add(game);

        //                }
        //            }

        //        }
        //    }

        //    return lista;
        //}

        // GET: api/Games/5

        

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

        // POST: api/Games
        //public IHttpActionResult Post(Game igra)
        //{
        //    using (var client = new SshClient("194.149.136.118", 22, "tunnelvezhbi", "tuneliranje!"))
        //    {
        //        client.Connect();

        //        var port = new ForwardedPortLocal("localhost", 5555, "localhost", 5432); //ova trebase obratno da bidat i dr porta ne e vazno koja porta. da se vnimava da ne e start localhost baza i tamu baza na ista porta
        //        client.AddForwardedPort(port);

        //        port.Start();
        //        // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
        //        using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
        //        {
        //            conn.Open();
        //            using (var cmd = new NpgsqlCommand())
        //            {
        //                cmd.Connection = conn;

        //                // Insert some data

        //                cmd.CommandText = "INSERT INTO public.games " +
        //                            "(gamesname,gamesdescription,gamesprice,gamesreleasedate,gamesdeveloper,gamesgenre) " +
        //                       $"VALUES('{igra.Name}','{igra.Description}',{igra.Price},'{igra.Date}','{igra.Developer}','{igra.Genre}');";

        //                cmd.ExecuteNonQuery();
        //            }
        //            port.Stop();
        //            client.Disconnect();
        //            return Ok("Added game");
        //        }

        //    }
        //}
        // PUT: api/Games/5

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

        // DELETE: api/Games/5
        public void Delete(int id)
        {
        }
    }
}
