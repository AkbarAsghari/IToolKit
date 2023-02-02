using Bit.BlazorUI;
using IToolKit.API.Enums.Tools.Ciphers;
using IToolKit.API.Enums.Tools.EncodersDecoders;
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

    bool _IsAutoUpdate = true;


    List<BitDropDownItem> CipherTypes = new List<BitDropDownItem>()
    {
        new BitDropDownItem()
        {
            ItemType = BitDropDownItemType.Normal,
            Text = "Encrypt",
            Value = "Encrypt"
        },
        new BitDropDownItem()
        {
            ItemType = BitDropDownItemType.Normal,
            Text = "Decrypt",
            Value = "Decrypt"
        }
    };

    private void OnCipherTypeChange(BitDropDownItem cipherType)
    {
        if (Enum.TryParse(cipherType.Value, true, out CipherTypesEnum type))
        {
            CipherType = type;
        }

        OnChangeEvent(String.Empty);
    }

    private async void OnChangeEvent(string value)
    {
        if (_IsAutoUpdate)
            await CalcHash();
    }

    async Task CalcHash()
    {
        if (String.IsNullOrEmpty(_InputValue) || String.IsNullOrEmpty(_SecurityValue))
        {
            _AESResult = String.Empty;
            return;
        }

        _AESResult = await _JSRuntime.InvokeAsync<string>($"IToolKit.Cipher.AES.{CipherType}", _InputValue, _SecurityValue);

        await this.InvokeAsync(() => StateHasChanged());  
    }
}

