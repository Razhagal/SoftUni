using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Foods
{
    internal class Fruit : Food
    {
        public Fruit(int quantity)
            : base(quantity)
        {
            this.FoodType = FoodType.Fruit;
        }
    }
}
