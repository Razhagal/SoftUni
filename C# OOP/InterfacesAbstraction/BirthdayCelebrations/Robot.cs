using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : IRobot, IIdentifiable
    {
        private string id;
        private string model;

        public string Id { get { return this.id; } set { this.id = value; } }
        public string Model { get { return this.model; } set { this.model = value; } }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
