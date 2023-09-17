using IToolKit.API.Enums.Tools.Formatters;
using IToolKit.API.Tools.Formatters;

namespace IToolKit.Pages.Tools.Formatters.XML;
partial class XML
{
    string _InputValue;
    string _XMLFormatedResult;
    FormatterSpacesEnum _SpacesEnum;

    private async Task OnJsonFormatterSpacesChange(FormatterSpacesEnum spacesEnum)
    {
        _SpacesEnum = spacesEnum;
        await Format();
    }

    async Task Format()
    {
        if (String.IsNullOrEmpty(_InputValue))
        {
            _XMLFormatedResult = String.Empty;
            return;
        }

        try
        {
            _XMLFormatedResult = FormatterTools.FormatXML(_InputValue, _SpacesEnum);
        }
        catch (Exception)
        {
            // Handle and throw if fatal exception here; don't just ignore them
            _XMLFormatedResult = String.Empty;
        }

        await Task.CompletedTask;
    }
}
