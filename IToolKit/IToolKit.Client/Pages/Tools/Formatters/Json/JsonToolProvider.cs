using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;
using IToolKit.Client.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Client.Pages.Tools.Formatters.Json
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
