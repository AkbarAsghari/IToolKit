using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.Graphics
{
    [Name(InternalName)]
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
