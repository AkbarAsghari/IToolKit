using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.Text
{
    [Name(InternalName)]
    [Order(4)]
    internal sealed class TextGroupToolProvider : GroupToolProviderBase
    {
        internal const string InternalName = "Text";
        public override string Header => InternalName;

        public override string MenuDisplayName => InternalName;

        public override string Description => throw new NotImplementedException();

        public override string Route => InternalName;

        public override Type Component => throw new NotImplementedException();
    }
}
