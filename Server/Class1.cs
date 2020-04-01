using Rebus.Activation;
using Rebus.Config;
using System;

namespace Server
{
    public class Class1
    {
        static void Main()
        {
            using (var activator = new BuiltinHandlerActivator())
            {
                Configure.With(activator)
                    .Transport(t => t.UseMsmq("server")) // creates a queue named server
                    .Start();

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
