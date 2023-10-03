using IToolKit.API.Interfaces;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Text.MarkdownPreview
{
    internal sealed class MarkdownPreviewToolProvider : IToolProvider
    {
        public string Header => "Markdown Preview";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
        
        public string Route => "Markdown";

        public Type Component => typeof(MarkdownPreview);
    }
}
