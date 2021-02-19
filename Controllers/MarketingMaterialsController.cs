using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Piranha;
using Piranha.Models;
using piranhacms.Models;

namespace piranhacms.Controllers
{
    [Route("api/marketing-materials")]
    public class MarketingMaterialsController : Controller
    {
        private readonly IApi _api;
        
        public MarketingMaterialsController(IApi api)
        {
            _api = api;
        }

        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var releasesPage = await _api.Pages.GetBySlugAsync("releases");
            string currentVersion = releasesPage.Regions.CurrentVersion.Value;

            var sitemap = await _api.Sites.GetSitemapAsync();
            var releasesPartialMap = sitemap.GetPartial(releasesPage.Id);

            ReleaseNotes currentRelease = null;
            List<ReleaseNotes> releaseNoteses = new List<ReleaseNotes>();

            foreach(SitemapItem subpage in releasesPartialMap) {
                var page = await _api.Pages.GetByIdAsync(subpage.Id);
                ReleaseNotes releaseNotes = new ReleaseNotes(
                    page.Title,
                    (DateTime) page.Regions.ReleaseNotesBody.ReleaseDate.Value,
                    page.Regions.ReleaseNotesBody.Notes.Value
                );

                releaseNoteses.Add(releaseNotes);

                if(releaseNotes.Version == currentVersion) {
                    currentRelease = releaseNotes;
                }
            }

            Releases releases = new Releases(
                currentRelease,
                releaseNoteses
            );

            return Json(releases);
        }

        [Route("test")]
        public async Task<IActionResult> GetTest()
        {
            var allPages = await _api.Pages.GetAllAsync();
            return Ok(allPages);
        }
    }
}