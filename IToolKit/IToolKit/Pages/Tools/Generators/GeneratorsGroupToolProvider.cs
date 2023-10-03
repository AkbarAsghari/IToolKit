using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.Generators
{
    [Name(InternameName)]
    [Order(3)]
    internal sealed class GeneratorsGroupToolProvider : GroupToolProviderBase
    {
        internal const string InternameName = "Generators";

        public override string Header => InternameName;

        public override string MenuDisplayName => InternameName;

        public override string Description => throw new NotImplementedException();

        public override string Route => InternameName;

        public override Type Component => throw new NotImplementedException();
    }
}
