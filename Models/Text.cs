using Piranha.AttributeBuilder;
using Piranha.Models;
using Piranha.Extend.Fields;
using Piranha.Extend;

namespace piranhacms.Models
{
    [PageType(Title = "Release Notes", UsePrimaryImage = false, UseExcerpt = false, UseBlocks = false)]
    public class Text : Page<StandardPage>
    {
        [Region]
        public HtmlField Body { get; set; }
    }
}