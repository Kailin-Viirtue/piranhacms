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
            var marketingMaterialsPage = await _api.Pages.GetBySlugAsync("marketing-materials");

            List<MarketingMaterialDTO> marketingMaterials = new List<MarketingMaterialDTO>();

            foreach(MarketingMaterialBlock block in marketingMaterialsPage.Blocks) {
                string mediaUrl;
                if(!block.IsExternalUrl.Value && block.Media.HasValue) {
                    mediaUrl = block.Media.Media.PublicUrl;
                }
                else {
                    mediaUrl = block.ExternalUrl.Value;
                }
                MarketingMaterialDTO marketingMaterial = new MarketingMaterialDTO(
                    block.Title,
                    block.Description,
                    mediaUrl,
                    block.Thumbnail.Media.PublicUrl
                );

                marketingMaterials.Add(marketingMaterial);
            }

            return Json(marketingMaterials);
        }

        [Route("test")]
        public async Task<IActionResult> GetTest()
        {
            var marketingMaterialsPage = await _api.Pages.GetBySlugAsync("marketing-materials");
            return Ok(marketingMaterialsPage);
        }
    }
}