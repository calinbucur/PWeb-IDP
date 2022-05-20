namespace Petaway.Core.Domain.Transport
{
    public class TransportIsNullException : Exception
    {
        public TransportIsNullException() : base($"Proposed transport doesn't exist")
        {
        }
    }
}
