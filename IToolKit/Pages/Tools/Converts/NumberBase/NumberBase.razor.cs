using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IToolKit.Pages.Tools.Converts.NumberBase
{
    public partial class NumberBase
    {
        [Inject] IJSRuntime _JSRuntime { get; set; }

        string _Hexadecimal;
        string _Decimal;
        string _Octal;
        string _Binary;

        string _CurrentValue;

        async Task OnChangeEvent(string value)
        {
            _CurrentValue = value;
            await Convert();
        }

        async Task Convert()
        {
            if (String.IsNullOrWhiteSpace(_CurrentValue))
            {
                _Decimal = _Hexadecimal = _Octal = _Binary = _CurrentValue;
                return;
            }
            try
            {
                _Decimal = _CurrentValue;
                _Hexadecimal = await _JSRuntime.InvokeAsync<string>($"IToolKit.Convert.ToHex", _CurrentValue);
                _Octal = await _JSRuntime.InvokeAsync<string>($"IToolKit.Convert.ToOct", _CurrentValue);
                _Binary = await _JSRuntime.InvokeAsync<string>($"IToolKit.Convert.ToBin", _CurrentValue);
            }
            catch
            {
                _Hexadecimal = _Decimal = _Octal = _Binary = String.Empty;
            }
        }
    }
}