using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Generators.UUID
{
    [Parent(GeneratorsGroupToolProvider.InternalName)]
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
