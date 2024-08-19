using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;
using IToolKit.Client.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Client.Pages.Tools.Formatters.XML
{
    [Parent(FormattersGroupToolProvider.InternalName)]
    [Order(2)]
    internal sealed class XMLToolProvider : IToolProvider
    {
        public string Header => "XML Fromatter";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => "XML";
        
        public string Route => "XML";

        public Type Component => typeof(XML);
    }
}
