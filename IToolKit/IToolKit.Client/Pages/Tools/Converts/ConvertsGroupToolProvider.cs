using IToolKit.Client.API.Attributes;

namespace IToolKit.Client.Pages.Tools.Converts
{
    [Name(InternalName)]
    [Order(2)]
    internal sealed class ConvertsGroupToolProvider : GroupToolProviderBase
    {
        internal const string InternalName = "Converts";

        public override string Header => InternalName;

        public override string MenuDisplayName => InternalName;

        public override string Description => throw new NotImplementedException();

        public override string Route => InternalName;

        public override Type Component => throw new NotImplementedException();
    }
}
