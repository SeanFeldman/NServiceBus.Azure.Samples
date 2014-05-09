using System.Diagnostics;
using NServiceBus.Features;

namespace VideoStore.Operations
{
    using NServiceBus;

	public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker, UsingTransport<AzureServiceBus>
    {
    }

    public class MyClass : IWantToRunWhenBusStartsAndStops
    {
        public void Start()
        {
            Trace.WriteLine(string.Format("The VideoStore.Operations endpoint is now started and ready to accept messages"));
        }

        public void Stop()
        {

        }
    }

    // We don't need it, so instead of configuring it, we disable it
    public class DisableTimeoutManager : INeedInitialization
    {
        public void Init()
        {
            Feature.Disable<TimeoutManager>();
            Feature.Disable<SecondLevelRetries>();
        }
    }
}
