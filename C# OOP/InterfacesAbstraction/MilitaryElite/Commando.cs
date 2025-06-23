using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    internal class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;

        public List<Mission> Missions { get { return this.missions; } private set { this.missions = value; } }

        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public void AddMission(Mission mission)
        {
            if (mission.State.Equals(Mission.InProgressMissionState) ||
                mission.State.Equals(Mission.FinishedMissionState))
            {
                this.Missions.Add(mission);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine("Missions:");
            for (int i = 0; i < this.missions.Count; i++)
            {
                builder.AppendLine("  " + this.missions[i].ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
