using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.Generators.Hash
{
    [Order(1)]
    internal sealed class HashToolProvider : IToolProvider
    {
        public string Header => "Hash";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
    }
}
