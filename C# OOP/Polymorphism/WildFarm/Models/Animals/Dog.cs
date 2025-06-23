using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    internal class Dog : Mammal
    {
        private const double WeightPerFoodUnitIncrease = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.AddFoodPreferrence(FoodType.Meat);
        }

        public override string AskForFood()
        {
            return $"Woof!";
        }

        public override void Eat(Food food)
        {
            Console.WriteLine(this.AskForFood());
            if (this.PreferredFoods.Contains(food.FoodType))
            {
                this.Weight += (food.Quantity * WeightPerFoodUnitIncrease);
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.FoodType}!");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
