using IRunes.App.ViewModels.Albums;
using IRunes.App.ViewModels.Tracks;
using IRunes.Models;
using IRunes.Services;

using SIS.HTTP.Responses;

using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;
using SIS.MvcFramework.Attributes.Security;

namespace IRunes.App.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService albumService;

        public AlbumController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        [Authorize]
        public HttpResponse All()
        {
            ICollection<Album> allAlbums = this.albumService.GetAllAlbums();

            if (allAlbums.Count != 0)
            {
                var albumViewModels = allAlbums
                    .Select(x => new AlbumAllViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToList();

                return this.View(albumViewModels);
            }

            return this.View(new List<AlbumAllViewModel>());
        }

        [Authorize]
        public HttpResponse Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(AlbumCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Albums/Create");
            }

            Album album = new Album()
            {
                Name = model.Name,
                Cover = model.Cover
            };

            this.albumService.CreateAlbum(album);

            return this.Redirect("/Albums/All");
        }

        [Authorize]
        public HttpResponse Details(string id)
        {
            Album albumFromDb = this.albumService.GetAlbumById(id);

            if (albumFromDb == null)
            {
                return this.Redirect("/Albums/All");
            }

            AlbumDetailsViewModel albumViewModel = new AlbumDetailsViewModel()
            {
                Id = albumFromDb.Id,
                Name = albumFromDb.Name,
                Cover = albumFromDb.Cover,
                Price = albumFromDb.Price,
                Tracks = albumFromDb.Tracks.Select(t => new TrackAlbumAllViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList()
            };

            return this.View(albumViewModel);
        }
    }
}
