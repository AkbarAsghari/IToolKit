using MudBlazor.Utilities;
using QRCoder;

namespace IToolKit.Pages.Tools.Graphics.QRCode;

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
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
        PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
        _Base64Image = Convert.ToBase64String(qrCode.GetGraphic(pixelsPerModule: 20,
            darkColorRgba: new byte[] { _DarkColor.R, _DarkColor.G, _DarkColor.B, _DarkColor.A },
            lightColorRgba: new byte[] { _LightColor.R, _LightColor.G, _LightColor.B, _LightColor.A }));
        await Task.CompletedTask;
    }
}
