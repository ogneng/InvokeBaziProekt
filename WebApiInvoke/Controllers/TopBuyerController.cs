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
    public class TopBuyerController : ApiController
    {
        // GET: api/TopBuyer
        public List<TopBuyer> Get()
        {
            List<TopBuyer> TopBuyer = new List<TopBuyer>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "(select u.usersid,c.costomersusername as Username, to_char(pgames.dateofpurchasegames, 'Month') as Datum, sum(g.gamesprice) as profitgames from invoke.users u, invoke.costomers c, invoke.creditcards cc, invoke.purchasegames pgames, invoke.games g where u.usersid = c.usersid and c.usersid = cc.cardsid and cc.cardsid = pgames.cardsid and pgames.gamesname = g.gamesname and g.gamesgenre = 'MOBA' and pgames.dateofpurchasegames between current_date - interval '4 month' and current_date group by u.usersid, c.costomersusername, Datum having sum(g.gamesprice) = (select max(profitGames) from(select c.costomersusername as Username, sum(g.gamesprice) as profitgames from invoke.users u, invoke.costomers c, invoke.creditcards cc, invoke.purchasegames pgames, invoke.games g where u.usersid = c.usersid and c.usersid = cc.cardsid and cc.cardsid = pgames.cardsid and pgames.gamesname = g.gamesname and g.gamesgenre = 'MOBA' and pgames.dateofpurchasegames between current_date - interval '4 month' and current_date group by c.costomersusername) as lista))";



                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            TopBuyer topbuyer = new TopBuyer();
                            topbuyer.UserID = reader.GetInt64(0);
                            topbuyer.UserName = reader.GetString(1);
                            topbuyer.Month = reader.GetString(2);
                            topbuyer.Profit = reader.GetInt64(3);

                            TopBuyer.Add(topbuyer);

                        }

                    }
                }
            }
            return TopBuyer;
        }

        // GET: api/TopBuyer/5
        public List<TopBuyer> Get(string id)
        {
            List<TopBuyer> TopBuyer = new List<TopBuyer>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "(select u.usersid,c.costomersusername as Username, to_char(pgames.dateofpurchasegames, 'Month') as Datum, sum(g.gamesprice) as profitgames from invoke.users u, invoke.costomers c, invoke.creditcards cc, invoke.purchasegames pgames, invoke.games g where u.usersid = c.usersid and c.usersid = cc.cardsid and cc.cardsid = pgames.cardsid and pgames.gamesname = g.gamesname and g.gamesgenre = '" + id + "' and pgames.dateofpurchasegames between current_date - interval '4 month' and current_date group by u.usersid, c.costomersusername, Datum having sum(g.gamesprice) = (select max(profitGames) from(select c.costomersusername as Username, sum(g.gamesprice) as profitgames from invoke.users u, invoke.costomers c, invoke.creditcards cc, invoke.purchasegames pgames, invoke.games g where u.usersid = c.usersid and c.usersid = cc.cardsid and cc.cardsid = pgames.cardsid and pgames.gamesname = g.gamesname and g.gamesgenre = '" + id + "' and pgames.dateofpurchasegames between current_date - interval '4 month' and current_date group by c.costomersusername) as lista))";



                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            TopBuyer topbuyer = new TopBuyer();
                            topbuyer.UserID = reader.GetInt64(0);
                            topbuyer.UserName = reader.GetString(1);
                            topbuyer.Month = reader.GetString(2);
                            topbuyer.Profit = reader.GetInt64(3);

                            TopBuyer.Add(topbuyer);

                        }

                    }
                }
            }
            return TopBuyer;
        }

        // POST: api/TopBuyer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TopBuyer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TopBuyer/5
        public void Delete(int id)
        {
        }
    }
}
