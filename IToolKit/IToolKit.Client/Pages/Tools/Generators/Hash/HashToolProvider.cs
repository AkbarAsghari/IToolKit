using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;
using IToolKit.Client.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Client.Pages.Tools.Generators.Hash
{
    [Parent(GeneratorsGroupToolProvider.InternameName)]
    [Order(1)]
    internal sealed class HashToolProvider : IToolProvider
    {
        public string Header => "Hash";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => Header;
        
        public string Route => "Hash";

        public Type Component => typeof(Hash);
    }
}
