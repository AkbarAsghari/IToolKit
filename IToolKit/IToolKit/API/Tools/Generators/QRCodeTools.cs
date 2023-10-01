using QRCoder;

namespace IToolKit.API.Tools.Generators
{
    public class QRCodeTools
    {
        static QRCodeGenerator qrGenerator = new QRCodeGenerator();

        public static string TextToBase64(string text)
        {
            return TextToBase64(text, new byte[] { 0, 0, 0 }, new byte[] { 255, 255, 255 });
        }
        public static string TextToBase64(string text, byte[] darkColorRgba, byte[] lightColorRgba)
        {
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            return Convert.ToBase64String(qrCode.GetGraphic(pixelsPerModule: 20, darkColorRgba, lightColorRgba));
        }
    }
}
