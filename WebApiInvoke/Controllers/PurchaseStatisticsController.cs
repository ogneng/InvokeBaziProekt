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
    public class PurchaseStatisticsController : ApiController
    {
        // GET: api/PurchaseStatistics
        public List<PurchaseStatistics> Get()
        {
            List<PurchaseStatistics> PurcheStatistics = new List<PurchaseStatistics>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select purchasedgame.m, (select sum(g.gamesprice) as totalgames from invoke.purchasegames pg, invoke.games g where pg.gamesname = g.gamesname and to_char(pg.dateofpurchasegames, 'Month') = purchasedgame.m), (select sum(i.itemsprice) as totalItems from invoke.purchaseitems pitems,invoke.items i where pitems.itemsid = i.itemsid and to_char(pitems.dateofpurchaseitems, 'Month') = purchasedgame.m), (select sum(g.gamesprice) from invoke.purchasegames pg,invoke.games g where pg.gamesname = g.gamesname and to_char(pg.dateofpurchasegames, 'Month') = purchasedgame.m) + (select sum(i.itemsprice) from invoke.purchaseitems pitems,invoke.items i where pitems.itemsid = i.itemsid and to_char(pitems.dateofpurchaseitems, 'Month') = purchasedgame.m) as total from( select distinct to_char(purchasegames.dateofpurchasegames, 'Month') as m from invoke.purchasegames) purchasedgame";



                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            PurchaseStatistics pg = new PurchaseStatistics();
                            pg.Month = reader.GetString(0);
                            pg.TotalGames = reader.GetInt64(1);
                            pg.TotalItems = reader.GetInt64(2);
                            pg.Total = reader.GetInt64(3);

                            PurcheStatistics.Add(pg);

                        }

                    }
                }
            }
            return PurcheStatistics;
        }

        // GET: api/PurchaseStatistics/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PurchaseStatistics
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PurchaseStatistics/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PurchaseStatistics/5
        public void Delete(int id)
        {
        }
    }
}
