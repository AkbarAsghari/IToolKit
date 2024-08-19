using IToolKit.Client.API.Attributes;

namespace IToolKit.Client.Pages.Tools.Graphics
{
    [Name(InternalName)]
    [Order(5)]
    internal sealed class GraphicsGroupToolProvider : GroupToolProviderBase
    {
        internal const string InternalName = "Graphics";
        public override string Header => InternalName;

        public override string MenuDisplayName => InternalName;

        public override string Description => throw new NotImplementedException();

        public override string Route => InternalName;

        public override Type Component => throw new NotImplementedException();
    }
}
