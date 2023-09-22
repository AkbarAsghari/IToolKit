using IToolKit.API.Tools.MarkdownConverter;
using Microsoft.AspNetCore.Components;

namespace IToolKit.Shared.Components.Markdown;

partial class MarkdownViewer
{
    [Parameter] public string Theme { get; set; }
    [Parameter] public string Markdown { get; set; }
    [Parameter] public string Height { get; set; }

    string HTML
    {
        get
        {
            if (String.IsNullOrEmpty(Markdown))
            {
                return String.Empty;
            }
            return MarkdownConverter.ToHTML(Markdown);
        }
    }
}
