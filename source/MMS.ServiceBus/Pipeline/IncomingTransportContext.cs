namespace MMS.Common.ServiceBusWrapper.Pipeline
{
    public class IncomingTransportContext : Context
    {
        public IncomingTransportContext(TransportMessage message)
        {
            this.Set(message);
        }

        public TransportMessage TransportMessage
        {
            get
            {
                return this.Get<TransportMessage>();
            }
        }
    }
}