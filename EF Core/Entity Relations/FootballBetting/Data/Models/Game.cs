﻿namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public double HomeTeamBetRate { get; set; }

        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }

        public int AwayTeamGoals { get; set; }

        public double AwayTeamBetRate { get; set; }

        public DateTime Datetime { get; set; }

        public double DrawBetRate { get; set; }

        public int Result { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
