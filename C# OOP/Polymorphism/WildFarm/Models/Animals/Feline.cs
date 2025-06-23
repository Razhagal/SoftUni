using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    internal abstract class Feline : Mammal
    {
        private string breed;

        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get { return breed; } set { breed = value; } }
    }
}
