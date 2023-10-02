using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders.HTML
{
    [Order(5)]
    [Parent(EncodersDecodersGroupToolProvider.InternalName)]
    internal sealed class HTMLToolProvider : IToolProvider
    {
        public string Header => "HTML Encoder / Decoder";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
    }
}
