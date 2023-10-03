using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.Formatters
{
    [Name(InternalName)]
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
