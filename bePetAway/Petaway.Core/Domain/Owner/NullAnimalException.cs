namespace Petaway.Core.Domain.Owner
{
    public class NullAnimalException : Exception
    {
        public NullAnimalException() : base($"Found null animal in owners list")
        {
        }
    }
}
