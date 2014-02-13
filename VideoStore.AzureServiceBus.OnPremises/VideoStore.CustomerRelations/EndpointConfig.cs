﻿using NServiceBus.Azure.Transports.WindowsAzureServiceBus;
using NServiceBus.Config;
namespace VideoStore.CustomerRelations
{
    using System;
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, UsingTransport<AzureServiceBus> { }
    
    public class MyClass : IWantToRunWhenBusStartsAndStops
    {
        public void Start()
        {
            Console.Out.WriteLine("The VideoStore.CustomerRelations endpoint is now started and subscribed to events from VideoStore.Sales");
        }

        public void Stop()
        {

        }
    }

    /// <summary>
    /// This is just here so that topics are created irrespective of boot order of the processes
    /// </summary>
    public class AutoCreateDependantTopics : IWantToRunWhenConfigurationIsComplete
    {
        public void Run()
        {
            var topicCreator = new AzureServicebusTopicCreator();

            topicCreator.Create(Address.Parse("VideoStore.Sales.Events"));
        }
    }
}
