using NServiceBus;

namespace VideoStore.Host
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Host
    {
        public void Customize(ConfigurationBuilder builder)
        {
        }
    }
}