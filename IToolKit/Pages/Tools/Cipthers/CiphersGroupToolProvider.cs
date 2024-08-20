using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.Cipthers
{
    [Name(InternalName)]
    [Order(2)]
    internal sealed class CiphersGroupToolProvider : GroupToolProviderBase
    {
        internal const string InternalName = "Ciphers";

        public override string Header => InternalName;

        public override string MenuDisplayName => InternalName;

        public override string Description => throw new NotImplementedException();

        public override string Route => InternalName;

        public override Type Component => throw new NotImplementedException();
    }
}
