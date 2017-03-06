using Warden.Common.Host;
using Warden.Services.Stats.Framework;
using Warden.Messages.Events.WardenChecks;

namespace Warden.Services.Stats
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebServiceHost
                .Create<Startup>(port: 5055)
                .UseAutofac(Bootstrapper.LifetimeScope)
                .UseRabbitMq(queueName: typeof(Program).Namespace)
                .SubscribeToEvent<WardenCheckResultProcessed>()
                .Build()
                .Run();
        }
    }
}
