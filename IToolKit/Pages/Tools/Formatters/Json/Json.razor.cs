using IToolKit.API.Enums.Tools.Formatters;
using IToolKit.API.Tools.Formatters;
using System.Text;

namespace IToolKit.Pages.Tools.Formatters.Json;
partial class Json
{
    string _InputValue;
    string _JsonFormatedResult;
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
            _JsonFormatedResult = String.Empty;
            return;
        }

        try
        {
            _JsonFormatedResult = FormatterTools.FormatJson(_InputValue, _SpacesEnum);

        }
        catch (Exception)
        {
            _JsonFormatedResult = String.Empty;
        }

        await Task.CompletedTask;
    }
}
