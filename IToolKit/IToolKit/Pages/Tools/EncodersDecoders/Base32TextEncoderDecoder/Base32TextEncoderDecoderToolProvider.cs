using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders.Base32TextEncoderDecoder
{
    [Order(2)]
    internal sealed class Base32TextEncoderDecoderToolProvider : IToolProvider
    {
        public string Header => "Base32 Text Encoder / Decoder";

        public string Description => throw new NotImplementedException();
    }
}
