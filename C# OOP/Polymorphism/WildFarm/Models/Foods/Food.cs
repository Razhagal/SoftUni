using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Foods
{
    internal abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get { return quantity; } set { quantity = value; } }
        public FoodType FoodType { get; protected set; }
    }
}
