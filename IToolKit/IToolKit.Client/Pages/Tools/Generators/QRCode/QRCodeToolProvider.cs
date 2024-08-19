using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;
using IToolKit.Client.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Client.Pages.Tools.Generators.QRCode
{
    [Parent(GeneratorsGroupToolProvider.InternameName)]
    [Order(4)]
    internal sealed class QRCodeToolProvider : IToolProvider
    {
        public string Header => "QR Code";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => Header;
        
        public string Route => "QRCode";

        public Type Component => typeof(QRCode);
    }
}
