using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            HeroFactory druidFactory = new DruidFactory();
            HeroFactory paladinFactory = new PaladinFactory();
            HeroFactory rogueFactory = new RogueFactory();
            HeroFactory warriorFactory = new WarriorFactory();

            int inputRows = int.Parse(Console.ReadLine()) * 2;
            string currentHeroName = string.Empty;
            HeroFactory currentFactory = null;
            for (int i = 0; i < inputRows; i++)
            {
                if (i % 2 == 0)
                {
                    currentHeroName = Console.ReadLine();
                }
                else
                {
                    string currentHeroClass = Console.ReadLine();
                    switch (currentHeroClass)
                    {
                        case "Druid":
                            currentFactory = druidFactory;
                            break;
                        case "Paladin":
                            currentFactory = paladinFactory;
                            break;
                        case "Rogue":
                            currentFactory = rogueFactory;
                            break;
                        case "Warrior":
                            currentFactory = warriorFactory;
                            break;
                        default:
                            currentFactory = null;
                            Console.WriteLine("Invalid hero!");
                            break;
                    }

                    if (currentFactory != null)
                    {
                        heroes.Add(currentFactory.GetHero(currentHeroName));
                    }
                    else
                    {
                        i -= 2;
                    }
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalHeroesPower = 0;
            for (int i = 0; i < heroes.Count; i++)
            {
                Console.WriteLine(heroes[i].CastAbility());
                totalHeroesPower += heroes[i].Power;
            }

            if (totalHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
