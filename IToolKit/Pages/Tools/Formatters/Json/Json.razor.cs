using System.Text;

namespace IToolKit.Pages.Tools.Formatters.Json;
partial class Json
{
    string _InputValue;
    string _JsonFormatedResult;

    async Task Format()
    {
        if (String.IsNullOrEmpty(_InputValue))
        {
            _JsonFormatedResult = String.Empty;
            return;
        }

        try
        {
          _JsonFormatedResult = JsonFormatterTools.FormatJson(_InputValue);
        
        }
        catch (Exception)
        {
            _JsonFormatedResult = String.Empty;
        }

        await this.InvokeAsync(() => StateHasChanged());
    }
}
