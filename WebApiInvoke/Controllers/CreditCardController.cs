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
    public class CreditCardController : ApiController
    {
        // GET: api/CreditCard
        public List<CreditCards> Get()
        {
            List<CreditCards> pomList = new List<CreditCards>();

            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from invoke.creditcards";

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            CreditCards card = new CreditCards();
                            card.CardID = reader.GetInt64(0);
                            card.UserID = reader.GetInt64(1);
                            card.CustomerUserName = reader.GetString(2);
                            card.CardNumber = reader.GetString(3);
                            card.CardCvCode = reader.GetInt64(4);
                            card.CardHolderName = reader.GetString(5);
                            card.CardHolderSurName = reader.GetString(6);
                            card.CardDateTime = (DateTime)reader.GetDateTime(7);
                            card.CardType = reader.GetString(8);

                            pomList.Add(card);
                        }

                    }
                }
            }
            return pomList;
        }

        // GET: api/CreditCard/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CreditCard
        public IHttpActionResult Post(CreditCards card)
        {
            // using (var conn = new NpgsqlConnection("Host = localhost; Port = 5432; Username = postgres; Database = invokeTest; "))
            using (var conn = new NpgsqlConnection("Host = localhost; Port = 5555; Username = db_201617z_va_proekt_invoke_mk_owner; Password = invoke_finki; Database = db_201617z_va_proekt_invoke_mk"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data

                    cmd.CommandText = "INSERT INTO invoke.creditcards " +
                                "(usersid, customerusername, cardsnumber, cardscvcode, cardscardholdername, cardscardholdersurname, cardsexpirationdate, cardstype) " +
                           $"VALUES({card.UserID},'{card.CustomerUserName}',{card.CardNumber},{card.CardCvCode},'{card.CardHolderName}','{card.CardHolderSurName}','{card.CardDateTime}','{card.CardType}');";

                    cmd.ExecuteNonQuery();
                }

                return Ok("Added card");
            }
        }

        // PUT: api/CreditCard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CreditCard/5
        public void Delete(int id)
        {
        }
    }
}
