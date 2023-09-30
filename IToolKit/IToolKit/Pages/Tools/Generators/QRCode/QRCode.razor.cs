using IToolKit.API.Tools.Generators;
using MudBlazor.Utilities;
using QRCoder;

namespace IToolKit.Pages.Tools.Generators.QRCode;

partial class QRCode
{
    QRCodeGenerator qrGenerator = new QRCodeGenerator();

    string _Input;
    string _Base64Image;
    MudColor _LightColor = new MudColor("#fffff1ff");
    MudColor _DarkColor = new MudColor("#000001ff");

    async Task OnColorsChange()
    {
        await OnTextChange(_Input);
    }

    async Task OnTextChange(string value)
    {
        _Input = value;
        _Base64Image = QRCodeTools.TextToBase64(text: value,
            darkColorRgba: new byte[] { _DarkColor.R, _DarkColor.G, _DarkColor.B, _DarkColor.A },
            lightColorRgba: new byte[] { _LightColor.R, _LightColor.G, _LightColor.B, _LightColor.A });
        await Task.CompletedTask;
    }
}
