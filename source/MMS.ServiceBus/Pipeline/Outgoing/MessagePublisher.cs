//-------------------------------------------------------------------------------
// <copyright file="MessagePublisher.cs" company="MMS AG">
//   Copyright (c) MMS AG, 2008-2015
// </copyright>
//-------------------------------------------------------------------------------

namespace MMS.ServiceBus.Pipeline.Outgoing
{
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using Microsoft.ServiceBus.Messaging;
    using ServiceBusMessageSender = Microsoft.ServiceBus.Messaging.MessageSender;

    public class MessagePublisher : IPublishMessages
    {
        private readonly ConcurrentDictionary<Topic, ServiceBusMessageSender> publisherCache =
            new ConcurrentDictionary<Topic, ServiceBusMessageSender>(); 

        private readonly MessagingFactory factory;

        public MessagePublisher(MessagingFactory factory)
        {
            this.factory = factory;
        }

        public async Task PublishAsync(TransportMessage message, PublishOptions options)
        {
            ServiceBusMessageSender sender;
            if (!this.publisherCache.TryGetValue(options.Topic, out sender))
            {
                sender = await this.factory.CreateMessageSenderAsync(options.Destination())
                    .ConfigureAwait(false);
                this.publisherCache.TryAdd(options.Topic, sender);
            }

            await sender.SendAsync(message.ToBrokeredMessage())
                .ConfigureAwait(false);
        }

        public async Task CloseAsync()
        {
            foreach (var sender in this.publisherCache.Values)
            {
                await sender.CloseAsync()
                    .ConfigureAwait(false);
            }

            this.publisherCache.Clear();
        }
    }
}