using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders.Unicode
{
    [Order(3)]
    internal sealed class UnicodeToolProvider : IToolProvider
    {
        public string Header => "Unicode Encode / Decode";

        public string Description => throw new NotImplementedException();
    }
}
