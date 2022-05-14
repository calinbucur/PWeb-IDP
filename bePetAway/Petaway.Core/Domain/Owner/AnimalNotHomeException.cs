namespace Petaway.Core.Domain.Owner
{
    public class AnimalNotHomeException : Exception
    {
        public AnimalNotHomeException(string userName, int animalId) : base($"User's {userName} animal with id {animalId} has already left the danger zone.")
        {
        }
    }
}
