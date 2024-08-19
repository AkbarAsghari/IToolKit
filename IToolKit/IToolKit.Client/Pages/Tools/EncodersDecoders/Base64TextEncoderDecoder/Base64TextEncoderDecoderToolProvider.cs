using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;

namespace IToolKit.Client.Pages.Tools.EncodersDecoders.Base64TextEncoderDecoder
{
    [Order(1)]
    [Parent(EncodersDecodersGroupToolProvider.InternalName)]
    internal sealed class Base64TextEncoderDecoderToolProvider : IToolProvider
    {
        public string Header => "Base64 Text Encoder / Decoder";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => "Base64 Text";

        public string Route => "Base64";

        public Type Component => typeof(Base64TextEncoderDecoder);
    }
}
