using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Foods
{
    internal class Vegetable : Food
    {
        public Vegetable(int quantity)
            : base(quantity)
        {
            this.FoodType = FoodType.Vegetable;
        }
    }
}
