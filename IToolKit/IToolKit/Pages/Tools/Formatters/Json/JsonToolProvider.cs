using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.Formatters.Json
{
    [Order(1)]
    internal sealed class JsonToolProvider : IToolProvider
    {
        public string Header => "Json Fromatter";

        public string Description => throw new NotImplementedException();
    }
}
