namespace MMS.Common.ServiceBusWrapper.Pipeline
{
    using System;
    using System.Threading.Tasks;

    public class DispatchToTransportPipelineStep : IOutgoingTransportPipelineStep
    {
        private readonly MessageSender sender;

        public DispatchToTransportPipelineStep(MessageSender sender)
        {
            this.sender = sender;
        }

        public async Task Invoke(OutgoingTransportContext context, Func<Task> next)
        {
            await this.sender.SendAsync(context.TransportMessage, (SendOptions)context.Options);

            await next();
        }
    }
}