using System;
using System.Collections.Generic;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();
            Dictionary<string, Soldier> privates = new Dictionary<string, Soldier>();

            string input = Console.ReadLine();
            while (!input.Equals("End"))
            {
                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string id = splitInput[1];
                string firstName = splitInput[2];
                string lastName = splitInput[3];
                decimal salary = 0m;
                string corps = string.Empty;
                if (!splitInput[0].Equals("Spy"))
                {
                    salary = decimal.Parse(splitInput[4]);
                }

                switch (splitInput[0])
                {
                    case "Private":
                        Soldier privateSoldier = new Private(id, firstName, lastName, salary);
                        privates.Add(privateSoldier.Id, privateSoldier);
                        soldiers.Add(privateSoldier);
                        break;
                    case "LieutenantGeneral":
                        LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);
                        if (splitInput.Length > 5)
                        {
                            for (int i = 5; i < splitInput.Length; i++)
                            {
                                if (privates.ContainsKey(splitInput[i]))
                                {
                                    general.AddPrivate((Private)privates[splitInput[i]]);
                                }
                            }
                        }

                        soldiers.Add(general);
                        break;
                    case "Engineer":
                        corps = splitInput[5];
                        if (IsValidCorp(corps))
                        {
                            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                            if (splitInput.Length > 6)
                            {
                                for (int i = 6; i < splitInput.Length; i+=2)
                                {
                                    string repairPartName = splitInput[i];
                                    int hoursWorkedOnPart = int.Parse(splitInput[i + 1]);
                                    engineer.AddRepair(new Repair(repairPartName, hoursWorkedOnPart));
                                }
                            }

                            soldiers.Add(engineer);
                        }
                        break;
                    case "Commando":
                        corps = splitInput[5];
                        if (IsValidCorp(corps))
                        {
                            Commando commando = new Commando(id, firstName, lastName, salary, corps);
                            if (splitInput.Length > 6)
                            {
                                for (int i = 6; i < splitInput.Length; i+=2)
                                {
                                    string missionCodeName = splitInput[i];
                                    string missionState = splitInput[i + 1];
                                    commando.AddMission(new Mission(missionCodeName, missionState));
                                }
                            }

                            soldiers.Add(commando);
                        }
                        break;
                    case "Spy":
                        Soldier spy = new Spy(id, firstName, lastName, int.Parse(splitInput[4]));
                        soldiers.Add(spy);
                        break;
                    default: break;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < soldiers.Count; i++)
            {
                Console.WriteLine(soldiers[i].ToString());
            }
        }

        private static bool IsValidCorp(string corpName)
        {
            if (corpName.Equals("Airforces") || corpName.Equals("Marines"))
            {
                return true;
            }

            return false;
        }
    }
}