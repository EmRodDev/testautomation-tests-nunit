using System.Diagnostics;

namespace TestAutomation.Tests.PageObjectPattern.Models
{
    public class FruitModel
    {


        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }

        public FruitModel(string name, decimal value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }
    }
}
