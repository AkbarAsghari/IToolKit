using IToolKit.API.Tools.MarkdownConverter;

namespace IToolKit.Pages.Tools.Text.MarkdownPreview;
partial class MarkdownPreview
{
    string _Markdown;
    string _Theme = "light";

    private async void OnInputChange(string value)
    {
        _Markdown = value;
        await Task.CompletedTask;
    }
}
