namespace Petaway.Core.Domain.Foster
{
    public class FosterFullCapacityException : Exception
    {
        public FosterFullCapacityException(int fosterId) : base($"Foster with id {fosterId} has already reached full capacity, can't get any new animal")
        {
        }
    }
}
