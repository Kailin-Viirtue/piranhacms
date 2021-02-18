using Microsoft.AspNetCore.Mvc;
using Piranha;

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
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}