using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Formatters.Json
{
    [Parent(FormattersGroupToolProvider.InternalName)]
    [Order(1)]
    internal sealed class JsonToolProvider : IToolProvider
    {
        public string Header => "Json Fromatter";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => "Json";
       
        public string Route => "Json";

        public Type Component => typeof(Json);
    }
}
