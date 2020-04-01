using Rebus.Activation;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientServer.Infrastructure
{
    public static class Client
    {
        public static void Start()
        {
            using (var activator = new BuiltinHandlerActivator())
            {
                var bus = Configure.With(activator)
                    .Transport(t => t.UseMsmq("client")) // Transport says what kind of transport are we using and we use msmq
                    .Routing(r => r.TypeBased().Map<string>("server")) // we are telling the server to map messages of type string to server
                    .Start();

                while (true)
                {
                    Console.Write("Type something > ");
                    var text = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(text))
                        break;

                    bus.Send(text).Wait();
                }
            }
        }
    }
}
