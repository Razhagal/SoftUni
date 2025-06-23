using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    internal class Mission : IMission
    {
        public const string InProgressMissionState = "inProgress";
        public const string FinishedMissionState = "Finished";

        private string codeName;
        private string state;

        public string CodeName { get { return this.codeName; } set { this.codeName = value; } }
        public string State { get { return this.state; } set { this.state = value; } }

        public Mission(string codeName, string missionState)
        {
            this.CodeName = codeName;
            this.State = missionState;
        }

        public void CompleteMission()
        {
            this.State = FinishedMissionState;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
