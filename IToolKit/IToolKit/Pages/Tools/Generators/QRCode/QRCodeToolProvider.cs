using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Generators.QRCode
{
    [Order(4)]
    internal sealed class QRCodeToolProvider : IToolProvider
    {
        public string Header => "QR Code";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
        
        public string Route => "QRCode";

        public Type Component => typeof(QRCode);
    }
}
