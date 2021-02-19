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
        [Field(Placeholder = "Optional")]
        public MediaField Media { get; set; }
        [Field(Title = "External URL?", Placeholder = "This media is a link to an external URL")]
        public CheckBoxField IsExternalUrl { get; set; }
        [Field(Title = "External URL", Placeholder = "Optional")]
        public StringField ExternalUrl { get; set; }
    }
}

