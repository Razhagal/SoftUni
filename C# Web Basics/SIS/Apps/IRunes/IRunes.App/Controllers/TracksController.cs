using IRunes.App.ViewModels.Tracks;
using IRunes.Models;
using IRunes.Services;

using SIS.HTTP.Responses;

using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;
using SIS.MvcFramework.Attributes.Security;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;

        public TracksController(ITrackService trackService, IAlbumService albumService)
        {
            this.trackService = trackService;
            this.albumService = albumService;
        }

        [Authorize]
        public HttpResponse Create(string albumId)
        {
            return this.View(new TrackCreateViewModel { AlbumId = albumId });
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(TrackCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            Track trackFromDb = new Track()
            {
                Name = model.Name,
                Link = model.Link,
                Price = model.Price,
                AlbumId = model.AlbumId
            };

            if (!this.albumService.AddTrackToAlbum(model.AlbumId, trackFromDb))
            {
                return this.Redirect("/Albums/All");
            }

            return this.Redirect($"/Albums/Details?id={model.AlbumId}");
        }

        [Authorize]
        public HttpResponse Details(TrackDetailsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Albums/All");
            }

            Track trackFromDb = this.trackService.GetTrackById(model.TrackId);
            if (trackFromDb == null)
            {
                return this.Redirect($"/Albums/Details?id={model.AlbumId}");
            }

            TrackDetailsViewModel trackDetailsViewModel = new TrackDetailsViewModel()
            {
                Name = trackFromDb.Name,
                Price = trackFromDb.Price.ToString(),
                Link = trackFromDb.Link,
                AlbumId = trackFromDb.AlbumId
            };

            return this.View(trackDetailsViewModel);
        }
    }
}
