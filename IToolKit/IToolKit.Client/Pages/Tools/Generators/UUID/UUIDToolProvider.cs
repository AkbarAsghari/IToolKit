using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;
using IToolKit.Client.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Client.Pages.Tools.Generators.UUID
{
    [Parent(GeneratorsGroupToolProvider.InternameName)]
    [Order(2)]
    internal sealed class UUIDToolProvider : IToolProvider
    {
        public string Header => "UUID";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => Header;
        
        public string Route => "UUID";

        public Type Component => typeof(UUID);
    }
}
