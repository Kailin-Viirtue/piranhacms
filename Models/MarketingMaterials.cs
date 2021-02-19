using Piranha.AttributeBuilder;
using Piranha.Models;
using Piranha.Extend.Fields;
using Piranha.Extend;

namespace piranhacms.Models
{
    [PageType(Title = "Marketing Materials", UsePrimaryImage = false, UseExcerpt = false, UseBlocks = true)]
    public class MarketingMaterialsPage : StandardPage
    {

    }

    [BlockType(Name = "Marketing Material", Category = "Marketing", Icon = "fas fa-bullhorn")]
    public class MarketingMaterialBlock : Block
    {
        public StringField Title { get; set; }
        public TextField Description { get; set; }
        public ImageField Thumbnail { get; set; }
        public MediaField Media { get; set; }
    }
}