using Piranha.AttributeBuilder;
using Piranha.Models;
using Piranha.Extend.Fields;
using Piranha.Extend;

namespace piranhacms.Models
{
    [PageType(Title = "Raw Text")]
    public class Text
    {
        [Field]
        public StringField Data { get; set; }
    }
}