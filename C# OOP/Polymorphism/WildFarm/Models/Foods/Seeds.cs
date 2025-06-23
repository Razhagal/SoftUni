using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Foods
{
    internal class Seeds : Food
    {
        public Seeds(int quantity)
            : base(quantity)
        {
            this.FoodType = FoodType.Seeds;
        }
    }
}
