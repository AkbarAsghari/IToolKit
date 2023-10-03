using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Text.StringEscapeUnescape
{
    [Order(3)]
    internal sealed class StringEscapeUnescapeToolProvider : IToolProvider
    {
        public string Header => "Text Escape / Unescape";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
        
        public string Route => "StringEscapeUnescape";

        public Type Component => typeof(StringEscapeUnescape);
    }
}
