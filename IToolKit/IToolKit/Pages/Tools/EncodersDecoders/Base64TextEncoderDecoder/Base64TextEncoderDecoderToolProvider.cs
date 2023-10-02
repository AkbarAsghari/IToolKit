using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders.Base64TextEncoderDecoder
{
    [Order(1)]
    internal sealed class Base64TextEncoderDecoderToolProvider : IToolProvider
    {
        public string Header => "Base64 Text Encoder / Decoder";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
    }
}
