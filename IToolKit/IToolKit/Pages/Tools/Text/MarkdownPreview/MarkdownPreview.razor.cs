using IToolKit.API.Tools.MarkdownConverter;

namespace IToolKit.Pages.Tools.Text.MarkdownPreview;
partial class MarkdownPreview
{
    string _Result;
    private async void OnInputChange(string value)
    {
        _Result = MarkdownConverter.ToHTML(value);
        await Task.CompletedTask;
    }
}
