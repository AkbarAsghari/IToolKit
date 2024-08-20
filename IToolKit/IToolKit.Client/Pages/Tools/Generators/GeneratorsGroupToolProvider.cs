using IToolKit.Client.API.Attributes;

namespace IToolKit.Client.Pages.Tools.Generators
{
    [Name(InternalName)]
    [Order(3)]
    internal sealed class GeneratorsGroupToolProvider : GroupToolProviderBase
    {
        internal const string InternalName = "Generators";

        public override string Header => InternalName;

        public override string MenuDisplayName => InternalName;

        public override string Description => throw new NotImplementedException();

        public override string Route => InternalName;

        public override Type Component => throw new NotImplementedException();
    }
}
