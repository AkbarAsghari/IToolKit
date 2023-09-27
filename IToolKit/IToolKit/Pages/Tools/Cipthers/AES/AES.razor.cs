using IToolKit.API.Enums.Tools.Ciphers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IToolKit.Pages.Tools.Cipthers.AES;
partial class AES
{
    [Inject] IJSRuntime _JSRuntime { get; set; }

    CipherTypesEnum CipherType = CipherTypesEnum.Encrypt;
    string _InputValue;
    string _SecurityValue;

    string _AESResult;

    private async Task OnCipherTypeChangeAsync(CipherTypesEnum cipherType)
    {
        CipherType = cipherType;
        await CalcHash();
    }

    private async void OnInputChange(string value)
    {
        _InputValue = value;
            await CalcHash();
    }

    private async void OnSecurityValueChange(string value)
    {
        _SecurityValue = value;
        await CalcHash();
    }

    async Task CalcHash()
    {
        if (String.IsNullOrEmpty(_InputValue) || String.IsNullOrEmpty(_SecurityValue))
        {
            _AESResult = String.Empty;
            return;
        }

        try
        {
            _AESResult = await _JSRuntime.InvokeAsync<string>($"IToolKit.Cipher.AES.{CipherType}", _InputValue, _SecurityValue);
        }
        catch (Exception)
        {
            _AESResult = String.Empty;
        }

        await this.InvokeAsync(() => StateHasChanged());
    }
}

