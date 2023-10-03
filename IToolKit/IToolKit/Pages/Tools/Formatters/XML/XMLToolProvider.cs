using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Formatters.XML
{
    [Order(2)]
    internal sealed class XMLToolProvider : IToolProvider
    {
        public string Header => "XML Fromatter";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
        
        public string Route => "XML";

        public Type Component => typeof(XML);
    }
}
