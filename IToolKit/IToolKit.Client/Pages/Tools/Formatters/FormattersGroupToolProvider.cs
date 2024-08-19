using IToolKit.Client.API.Attributes;

namespace IToolKit.Client.Pages.Tools.Formatters
{
    [Name(InternalName)]
    [Order(1)]
    internal sealed class FormattersGroupToolProvider : GroupToolProviderBase
    {
        internal const string InternalName = "Formatters";

        public override string Header => "Formatters";

        public override string MenuDisplayName => Header;

        public override string Description => throw new NotImplementedException();

        public override string Route => Header;

        public override Type Component => throw new NotImplementedException();
    }
}
