using System;
using System.Collections.Generic;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input = Console.ReadLine();
            int index = 0;
            Animal currentAnimal = null;
            while (!input.Equals("End"))
            {
                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (index % 2 == 0)
                {
                    string animalType = splitInput[0];
                    string animalName = splitInput[1];
                    double animalWeight = double.Parse(splitInput[2]);
                    double wingSize;
                    string livingRegion;
                    string breed;

                    switch (animalType)
                    {
                        case "Owl":
                            wingSize = double.Parse(splitInput[3]);
                            currentAnimal = new Owl(animalName, animalWeight, wingSize);
                            break;
                        case "Hen":
                            wingSize = double.Parse(splitInput[3]);
                            currentAnimal = new Hen(animalName, animalWeight, wingSize);
                            break;
                        case "Mouse":
                            livingRegion = splitInput[3];
                            currentAnimal = new Mouse(animalName, animalWeight, livingRegion);
                            break;
                        case "Dog":
                            livingRegion = splitInput[3];
                            currentAnimal = new Dog(animalName, animalWeight, livingRegion);
                            break;
                        case "Cat":
                            livingRegion = splitInput[3];
                            breed = splitInput[4];
                            currentAnimal = new Cat(animalName, animalWeight, livingRegion, breed);
                            break;
                        case "Tiger":
                            livingRegion = splitInput[3];
                            breed = splitInput[4];
                            currentAnimal = new Tiger(animalName, animalWeight, livingRegion, breed);
                            break;
                    }

                    animals.Add(currentAnimal);
                    index++;
                }
                else
                {
                    string foodType = splitInput[0];
                    int foodQuantity = int.Parse(splitInput[1]);
                    Food currentFood = null;
                    switch (foodType)
                    {
                        case "Vegetable":
                            currentFood = new Vegetable(foodQuantity);
                            break;
                        case "Fruit":
                            currentFood = new Fruit(foodQuantity);
                            break;
                        case "Meat":
                            currentFood = new Meat(foodQuantity);
                            break;
                        case "Seeds":
                            currentFood = new Seeds(foodQuantity);
                            break;
                    }

                    currentAnimal.Eat(currentFood);

                    index = 0;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i].ToString());
            }
        }
    }
}
