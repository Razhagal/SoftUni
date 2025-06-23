using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    internal abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;
        private HashSet<FoodType> preferredFoods;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.PreferredFoods = new HashSet<FoodType>();
        }

        public string Name { get { return name; } set { name = value; } }
        public double Weight { get { return weight; } set { weight = value; } }
        public int FoodEaten { get { return foodEaten; } set { foodEaten = value; } }
        public HashSet<FoodType> PreferredFoods { get { return this.preferredFoods; } private set { this.preferredFoods = value; } }

        public abstract string AskForFood();
        public abstract void Eat(Food food);
        protected void AddFoodPreferrence(params FoodType[] foodType)
        {
            for (int i = 0; i < foodType.Length; i++)
            {
                this.PreferredFoods.Add(foodType[i]);
            }
        }
    }
}
