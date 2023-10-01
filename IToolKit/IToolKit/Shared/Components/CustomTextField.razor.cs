using IToolKit.API.Enums.Components;
using IToolKit.API.Tools.Generators;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using QRCoder;
using System.Security.Cryptography.X509Certificates;

namespace IToolKit.Shared.Components;
partial class CustomTextField
{
    [Parameter] public bool MonoSpace { get; set; }
    [Inject] IDialogService DialogService { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        base.Variant = Variant.Outlined;
        if (MonoSpace)
        {
            if (String.IsNullOrEmpty(Class))
            {
                Class = "font-monospace";
            }
            else
            {
                Class += " font-monospace";
            }
        }
    }

    private async Task Copy()
    {
        await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", Text);
    }

    private async Task GenerateQRCode()
    {
        if (String.IsNullOrEmpty(Text))
        {
            return;
        }

        await DialogService.ShowAsync<CustomImage>(
             "QR Code",
             parameters: new DialogParameters<CustomImage> {
                { x => x.Src, QRCodeTools.TextToBase64(Text) },
                { x => x.ImageType, ImageTypeEnum.Base64 } },
             options: new DialogOptions
             {
                 MaxWidth = MaxWidth.ExtraSmall,
                 CloseButton = true,
             });
    }
}
