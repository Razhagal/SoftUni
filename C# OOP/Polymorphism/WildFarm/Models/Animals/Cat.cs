using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    internal class Cat : Feline
    {
        private const double WeightPerFoodUnitIncrease = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AddFoodPreferrence(FoodType.Vegetable, FoodType.Meat);
        }

        public override string AskForFood()
        {
            return $"Meow";
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
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
