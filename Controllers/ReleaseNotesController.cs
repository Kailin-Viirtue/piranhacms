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
    [Route("api/release-notes")]
    public class ReleaseNotesController : Controller
    {
        private readonly IApi _api;
        
        public ReleaseNotesController(IApi api)
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

            ReleaseNotesDTO currentRelease = null;
            List<ReleaseNotesDTO> releaseNoteses = new List<ReleaseNotesDTO>();

            foreach(SitemapItem subpage in releasesPartialMap) {
                var page = await _api.Pages.GetByIdAsync(subpage.Id);
                ReleaseNotesDTO releaseNotes = new ReleaseNotesDTO(
                    page.Title,
                    (DateTime) page.Regions.ReleaseNotesBody.ReleaseDate.Value,
                    page.Regions.ReleaseNotesBody.Notes.Value
                );

                releaseNoteses.Add(releaseNotes);

                if(releaseNotes.Version == currentVersion) {
                    currentRelease = releaseNotes;
                }
            }

            ReleasesDTO releases = new ReleasesDTO(
                currentRelease,
                releaseNoteses
            );

            return Json(releases);
        }

        [Route("test")]
        public async Task<IActionResult> GetTest()
        {
            var releaseNotesPages = new List<DynamicPage>();
            var allPages = await _api.Pages.GetAllAsync();

            foreach(DynamicPage page in allPages) {
                if(page.TypeId == "ReleaseNotesPage") {
                    releaseNotesPages.Add(page);
                }
            }

            return Ok(releaseNotesPages);
        }
    }
}