using Markdig;

namespace IToolKit.API.Tools.MarkdownConverter
{
    public static class MarkdownConverter
    {
        public static string ToHTML(string markdown)
        {
            return Markdown.ToHtml(markdown, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
        }

    }
}
