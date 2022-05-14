namespace Petaway.Core.Domain.Owner
{
    public class AnimalNotFoundException : Exception
    {
        public AnimalNotFoundException(string userName, int animalId) : base($"User's {userName} animal with id {animalId} not found!")
        {
        }
    }
}
