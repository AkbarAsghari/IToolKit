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

        private void OnChangeEvent(string value)
        {
            Console.WriteLine(value);
            _CurrentValue = value;

            if (_IsAutoUpdate)
                CalcHash();
        }

        async void CalcHash()
        {
            if (String.IsNullOrWhiteSpace(_CurrentValue))
            {
                _MD5Result = _SHA1Result = _SHA256Result = _SHA384Result = _SHA512Result = String.Empty;
                return;
            }

            _MD5Result = await _JSRuntime.InvokeAsync<string>("md5", _CurrentValue);
            _SHA1Result = HashingsTool.ComputeSHA1Hash(_CurrentValue);
            _SHA256Result = HashingsTool.ComputeSHA256Hash(_CurrentValue);
            _SHA384Result = HashingsTool.ComputeSHA384Hash(_CurrentValue);
            _SHA512Result = HashingsTool.ComputeSHA512Hash(_CurrentValue);

            ChangeTextCase(_IsUpperCase);
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
