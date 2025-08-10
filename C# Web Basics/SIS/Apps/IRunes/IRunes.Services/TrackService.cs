using IRunes.Data;
using IRunes.Models;

namespace IRunes.Services
{
    public class TrackService : ITrackService
    {
        private readonly RunesDbContext context;

        public TrackService(RunesDbContext dbContext)
        {
            this.context = dbContext;
        }

        public Track GetTrackById(string trackId)
        {
            return this.context.Tracks
                .SingleOrDefault(t => t.Id == trackId);
        }
    }
}
