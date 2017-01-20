using Npgsql;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiInvoke.Models;

namespace WebApiInvoke.Models
{

    public static class ClientHelperClass
    {
        static SshClient client;
        public static void connect()
        {
            if (client == null || !client.IsConnected)
            {
                client = new SshClient("194.149.136.118", 22, "tunnelvezhbi", "tuneliranje!");
                client.Connect();

                var port = new ForwardedPortLocal("localhost", 5555, "localhost", 5432); //ova trebase obratno da bidat i dr porta ne e vazno koja porta. da se vnimava da ne e start localhost baza i tamu baza na ista porta
                client.AddForwardedPort(port);

                port.Start();

            }
        }
    }
}
