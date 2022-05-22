namespace Petaway.Core.Domain.Owner
{
    public class AnimalNotHomeException : Exception
    {
        public AnimalNotHomeException(string userName, string animalName, string animalType, int animalAge) : base($"User's {userName} animal {animalType} with name {animalName} and age {animalAge} has already left the danger zone.")
        {

        }
        public AnimalNotHomeException(string userName, int animalId) : base($"User's {userName} animal with id {animalId} has already left the danger zone.")
        {
        }
    }
}
