//-------------------------------------------------------------------------------
// <copyright file="PublishOptions.cs" company="MMS AG">
//   Copyright (c) MMS AG, 2008-2015
// </copyright>
//-------------------------------------------------------------------------------

namespace MMS.ServiceBus
{
    using System;

    public class PublishOptions : DeliveryOptions
    {
        public Type EventType { get; internal set; }

        public Topic Topic { get; internal set; }
    }
}