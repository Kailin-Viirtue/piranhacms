using Piranha.AttributeBuilder;
using Piranha.Models;
using Piranha.Extend.Fields;
using Piranha.Extend;

namespace piranhacms.Models
{
    [PageType(Title = "Releases", UsePrimaryImage = false, UseExcerpt = false, UseBlocks = false)]
    public class ReleasesPage : StandardPage
    {
        [Region]
        [RegionDescription("Current Release Version: ")]
        public StringField CurrentVersion { get; set; }
    }
}