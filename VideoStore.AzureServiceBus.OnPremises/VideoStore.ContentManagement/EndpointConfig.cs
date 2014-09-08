using NServiceBus.Azure.Transports.WindowsAzureServiceBus;
using NServiceBus.Config;
using NServiceBus.Hosting.Helpers;

namespace VideoStore.ContentManagement
{
    using System;
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server {

        public void Customize(BusConfiguration builder)
        {
            builder.UseTransport<AzureServiceBus>();
            builder.UsePersistence<InMemoryPersistence>();

            builder.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("VideoStore") && t.Namespace.EndsWith("Commands"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("VideoStore") && t.Namespace.EndsWith("Events"))
                .DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("VideoStore") && t.Namespace.EndsWith("RequestResponse"))
                .DefiningEncryptedPropertiesAs(p => p.Name.StartsWith("Encrypted"));

            builder.RijndaelEncryptionService();
        }
      
    }
    
    public class MyClass : IWantToRunWhenBusStartsAndStops
    {
        public void Start()
        {
            Console.Out.WriteLine("The VideoStore.ContentManagement endpoint is now started and subscribed to OrderAccepted events from VideoStore.Sales");
        }

        public void Stop()
        {

        }
    }

}
