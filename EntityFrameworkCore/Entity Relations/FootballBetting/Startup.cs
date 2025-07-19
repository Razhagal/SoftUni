using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class Startup
    {
        static void Main(string[] args)
        {
            FootballBettingContext dbContext = new FootballBettingContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}