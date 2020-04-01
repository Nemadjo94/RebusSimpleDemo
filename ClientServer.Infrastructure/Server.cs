using Rebus.Activation;
using Rebus.Config;
using System;

namespace ClientServer.Infrastructure
{
    public static class Server
    {
        public static void Start()
        {
            using (var activator = new BuiltinHandlerActivator())
            {

                #region handler
                activator.Handle<string>(async message =>
                {
                    Console.WriteLine("Message: " + message);
                });
                #endregion

                Configure.With(activator)
                    .Transport(t => t.UseMsmq("server")) // Transport says what kind of transport are we using and we use msmq
                    .Start();

                Console.WriteLine("Press ENTER to quit");
                Console.ReadLine();
            }
        }
    }
}
