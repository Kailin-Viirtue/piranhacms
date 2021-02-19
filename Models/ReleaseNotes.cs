using Piranha.AttributeBuilder;
using Piranha.Models;
using Piranha.Extend.Fields;
using Piranha.Extend;

namespace piranhacms.Models
{
    [PageType(Title = "Release Version", UsePrimaryImage = false, UseExcerpt = false, UseBlocks = false)]
    public class ReleaseNotesPage : StandardPage
    {
        [Region]
        public ReleaseNotesBody ReleaseNotesBody { get; set; }
    }

    public class ReleaseNotesBody
    {
        [Field(Title = "Release Date")]
        public DateField ReleaseDate { get; set; }
        [Field(Title = "Notes")]
        public HtmlField Notes { get; set; }
    }

}