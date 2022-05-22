namespace Petaway.Core.Domain.Transport
{
    public class TransportNotFound : Exception
    {
        public TransportNotFound() : base($"Proposed transport doesn't exist")
        {
        }
    }
}
