using System;

namespace API.Models
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";/*cat, dog, exotic (zoo animals), etc*/
        public bool IsHome { get; set; }
        public string Description { get; set; } = "";
        public bool IsAggresive { get; set; }
        public bool IsSick { get; set; }
        public bool IsStray { get; set; }
        public int Age { get; set; }
        public string Location { get; set; } = "";
    }
}