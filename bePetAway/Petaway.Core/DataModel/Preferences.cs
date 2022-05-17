
namespace Petaway.Core.DataModel
{
    public class Preferences
    {
        public Preferences(string type, string isAgg, string isSick, string isStray)
        {
            Type = type; /*all, cat, dog, rodent, bird, domestic, exotic*/
            IsAggresive = isAgg; /*all, aggressive, calm*/
            IsSick = isSick; /*all, healthy, sick*/
            IsStray = isStray; /*all, healthy, sick*/
        }
        public string Type { get; set; }
        public string IsAggresive { get; set; }
        public string IsSick { get; set; }
        public string IsStray { get; set; }
    }
}