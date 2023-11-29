using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.Converts.NumberBase
{
    [Order(1)]
    [Parent(ConvertsGroupToolProvider.InternalName)]
    internal sealed class NumberBaseToolProvider : IToolProvider
    {
        public string Header => "Number Base Converter";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => "Number Base";

        public string Route => "NumberBase";

        public Type Component => typeof(NumberBase);
    }
}
