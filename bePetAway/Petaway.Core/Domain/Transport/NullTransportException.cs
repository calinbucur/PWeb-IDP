namespace Petaway.Core.Domain.Transport
{
    public class NullTransportException : Exception
    {
        public NullTransportException() : base($"Found null transport in rescuer's history list")
        {
        }
    }
}
