﻿//-------------------------------------------------------------------------------
// <copyright file="OutgoingTransportContext.cs" company="MMS AG">
//   Copyright (c) MMS AG, 2008-2015
// </copyright>
//-------------------------------------------------------------------------------

namespace MMS.ServiceBus.Pipeline.Outgoing
{
    public class OutgoingTransportContext : Context
    {
        public OutgoingTransportContext(LogicalMessage message, TransportMessage transportMessage, DeliveryOptions options)
        {
            this.Set(message);
            this.Set(transportMessage);
            this.Set(options);
        }

        public LogicalMessage LogicalMessage
        {
            get
            {
                return this.Get<LogicalMessage>();
            }
        }

        public TransportMessage TransportMessage
        {
            get
            {
                return this.Get<TransportMessage>();
            }
        }

        public DeliveryOptions Options
        {
            get
            {
                return this.Get<DeliveryOptions>();
            }
        }
    }
}