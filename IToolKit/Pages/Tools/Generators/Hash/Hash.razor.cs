using Bit.BlazorUI;
using IToolKit.API.Enums.Tools.Hashings;
using IToolKit.API.Tools.Hashings;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IToolKit.Pages.Tools.Generators.Hash
{
    public partial class Hash
    {
        [Inject] IJSRuntime _JSRuntime { get; set; }

        string _CurrentValue;

        string _MD5Result;
        string _SHA1Result;
        string _SHA256Result;
        string _SHA384Result;
        string _SHA512Result;

        bool _IsAutoUpdate = true;
        bool _IsUpperCase = true;

        private async void OnChangeEvent(string value)
        {
            _CurrentValue = value;

            if (_IsAutoUpdate)
                await CalcHash();
        }

        async Task CalcHash()
        {
            if (String.IsNullOrWhiteSpace(_CurrentValue))
            {
                _MD5Result = _SHA1Result = _SHA256Result = _SHA384Result = _SHA512Result = String.Empty;
                return;
            }

            _MD5Result = await _JSRuntime.InvokeAsync<string>("IToolKit.MD5", _CurrentValue);
            _SHA1Result = await _JSRuntime.InvokeAsync<string>("IToolKit.SHA1", _CurrentValue);
            _SHA256Result = await _JSRuntime.InvokeAsync<string>("IToolKit.SHA256", _CurrentValue);
            _SHA384Result = await _JSRuntime.InvokeAsync<string>("IToolKit.SHA384", _CurrentValue);
            _SHA512Result = await _JSRuntime.InvokeAsync<string>("IToolKit.SHA512", _CurrentValue);

            ChangeTextCase(_IsUpperCase);
            await this.InvokeAsync(() => StateHasChanged());
        }

        void ChangeTextCase(bool value)
        {
            if (!value)
            {
                _MD5Result = _MD5Result.ToLower();
                _SHA1Result = _SHA1Result.ToLower();
                _SHA256Result = _SHA256Result.ToLower();
                _SHA384Result = _SHA384Result.ToLower();
                _SHA512Result = _SHA512Result.ToLower();
            }
            else
            {
                _MD5Result = _MD5Result.ToUpper();
                _SHA1Result = _SHA1Result.ToUpper();
                _SHA256Result = _SHA256Result.ToUpper();
                _SHA384Result = _SHA384Result.ToUpper();
                _SHA512Result = _SHA512Result.ToUpper();
            }
        }
    }
}
