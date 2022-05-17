namespace Petaway.Core.Domain.Rescuer
{
    public class RescuerFullCapacityException : Exception
    {
        public RescuerFullCapacityException(int fosterId) : base($"Rescuer with id {fosterId} has already reached full capacity, can't get any new animal")
        {
        }
    }
}
