using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Foods
{
    internal class Meat : Food
    {
        public Meat(int quantity)
            : base(quantity)
        {
            this.FoodType = FoodType.Meat;
        }
    }
}
