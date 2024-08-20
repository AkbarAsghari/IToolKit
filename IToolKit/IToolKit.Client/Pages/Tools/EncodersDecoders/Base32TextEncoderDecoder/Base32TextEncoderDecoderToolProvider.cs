using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;

namespace IToolKit.Client.Pages.Tools.EncodersDecoders.Base32TextEncoderDecoder
{
    [Order(2)]
    [Parent(EncodersDecodersGroupToolProvider.InternalName)]
    internal sealed class EncodersDecoders : IToolProvider
    {
        public string Header => "Base32 Text Encoder / Decoder";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => "Base32 Text";

        public string Route => "Base32";

        public Type Component => typeof(Base32TextEncoderDecoder);
    }
}
