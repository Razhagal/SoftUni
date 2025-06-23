using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    internal class Owl : Bird
    {
        private const double WeightPerFoodUnitIncrease = 0.25; 

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AddFoodPreferrence(FoodType.Meat);
        }

        public override string AskForFood()
        {
            return $"Hoot Hoot";
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
                Console.WriteLine($"{this.GetType().Name}  does not eat {food.FoodType}!");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
