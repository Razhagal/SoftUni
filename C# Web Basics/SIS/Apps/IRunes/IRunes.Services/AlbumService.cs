using IRunes.Data;
using IRunes.Models;
using Microsoft.EntityFrameworkCore;

namespace IRunes.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly RunesDbContext context;

        public AlbumService(RunesDbContext runesDbContext)
        {
            this.context = runesDbContext;
        }

        public Album CreateAlbum(Album album)
        {
            album = context.Albums.Add(album).Entity;
            this.context.SaveChanges();

            return album;
        }

        public bool AddTrackToAlbum(string albumId, Track track)
        {
            Album albumFromDb = this.GetAlbumById(albumId);
            if (albumFromDb == null)
            {
                return false;
            }

            albumFromDb.Tracks.Add(track);
            albumFromDb.Price = (albumFromDb.Tracks.Select(t => t.Price).Sum() * 87) / 100;

            this.context.Update(albumFromDb);
            this.context.SaveChanges();

            return true;
        }

        public ICollection<Album> GetAllAlbums()
        {
            return this.context.Albums.ToList();
        }

        public Album GetAlbumById(string id)
        {
            return this.context.Albums
                .Include(a => a.Tracks)
                .SingleOrDefault(a => a.Id == id);
        }
    }
}
