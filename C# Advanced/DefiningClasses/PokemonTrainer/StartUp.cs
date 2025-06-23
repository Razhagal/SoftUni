using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainersDict = new Dictionary<string, Trainer>();
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();
            while (!input.Equals("Tournament"))
            {
                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = splitInput[0];
                string pokemonName = splitInput[1];
                string pokemonType = splitInput[2];
                int pokemonHealth = int.Parse(splitInput[3]);

                Trainer trainer;
                Pokemon pokemon = new Pokemon(pokemonName, pokemonType, pokemonHealth);
                if (!trainersDict.ContainsKey(trainerName))
                {
                    trainer = new Trainer(trainerName);
                    trainersDict.Add(trainerName, trainer);
                    trainers.Add(trainer);
                }

                trainer = trainersDict[trainerName];
                trainer.Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (!input.Equals("End"))
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    Trainer currentTrainer = trainers[i];
                    if (currentTrainer.Pokemons.Any(x => x.Element.Equals(input)))
                    {
                        currentTrainer.BadgesCount++;
                    }
                    else
                    {
                        currentTrainer.Pokemons.ForEach(x => x.Health -= 10);
                        currentTrainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }

                input = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(x => x.BadgesCount).ToList();
            trainers.ForEach(x => Console.WriteLine($"{x.Name} {x.BadgesCount} {x.Pokemons.Count}"));
        }
    }
}