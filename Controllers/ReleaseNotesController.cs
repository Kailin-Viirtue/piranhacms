using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Piranha;
using Piranha.Models;

namespace piranhacms.Controllers
{
    [Route("api/release-notes")]
    public class ReleaseNotesController : Controller
    {

        /* {
            "currentRelease": {
                "version": "2.0.0",
                "releaseDate": Date,
                "notes": "string"
            },
            "releaseNotes": [
                {
                    "version": "1.0.0",
                    "releaseDate": Date,
                    "notes": "string"
                },
                {
                    "version": "2.0.0",
                    "releaseDate": Date,
                    "notes": "string"
                }
            ]
        }
         */
        private readonly IApi _api;
        
        public ReleaseNotesController(IApi api)
        {
            _api = api;
        }

        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var releaseNotesParent = await _api.Pages.GetBySlugAsync("release-notes");
            var releaseNotesPages = new List<System.Object>();

            var sitemap = await _api.Sites.GetSitemapAsync();
            var releaseNotesPartialMap = sitemap.GetPartial(releaseNotesParent.Id);

            foreach(SitemapItem subpage in releaseNotesPartialMap) {
                var page = await _api.Pages.GetByIdAsync(subpage.Id);

                var noteJson = new {
                    version = page.Title,
                    releaseDate = page.Created,
                    notes = page.Regions.Body.Value
                };
                releaseNotesPages.Add(noteJson);
            }

            return Json(releaseNotesPages);
        }

        [Route("test")]
        public async Task<IActionResult> GetTest()
        {
            var releaseNotesPages = new List<DynamicPage>();
            var allPages = await _api.Pages.GetAllAsync();

            foreach(DynamicPage page in allPages) {
                if(page.TypeId == "Text") {
                    releaseNotesPages.Add(page);
                }
            }

            return Ok(releaseNotesPages);
        }
    }
}