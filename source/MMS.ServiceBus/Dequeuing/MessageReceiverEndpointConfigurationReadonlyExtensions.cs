//-------------------------------------------------------------------------------
// <copyright file="MessageReceiverEndpointConfigurationReadonlyExtensions.cs" company="MMS AG">
//   Copyright (c) MMS AG, 2008-2015
// </copyright>
//-------------------------------------------------------------------------------

namespace MMS.ServiceBus.Dequeuing
{
    using Microsoft.ServiceBus.Messaging;

    internal static class MessageReceiverEndpointConfigurationReadonlyExtensions
    {
        public static MessageReceiver Configure(this EndpointConfiguration.ReadOnly configuration, MessageReceiver receiver)
        {
            receiver.PrefetchCount = configuration.PrefetchCount;
            return receiver;
        }

        public static OnMessageOptions Options(this EndpointConfiguration.ReadOnly configuration)
        {
            return new OnMessageOptions { AutoComplete = true, MaxConcurrentCalls = configuration.MaxConcurrency };
        }

        public static string DestinationQueue(this EndpointConfiguration.ReadOnly configuration)
        {
            return configuration.EndpointQueue.Destination;
        }
    }
}