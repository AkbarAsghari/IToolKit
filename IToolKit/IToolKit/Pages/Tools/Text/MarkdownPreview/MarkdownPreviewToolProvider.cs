using IToolKit.API.Attributes;
using IToolKit.API.Interfaces;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Text.MarkdownPreview
{
    [Parent(TextGroupToolProvider.InternalName)]
    [Order(4)]
    internal sealed class MarkdownPreviewToolProvider : IToolProvider
    {
        public string Header => "Markdown Preview";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => Header;
        
        public string Route => "Markdown";

        public Type Component => typeof(MarkdownPreview);
    }
}
