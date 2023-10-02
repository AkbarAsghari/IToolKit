using IToolKit.API.Interfaces;

namespace IToolKit.Pages.Tools
{
    internal abstract class GroupToolProviderBase : IToolProvider
    {
        public abstract string Header { get; }

        public abstract string MenuDisplayName { get; }

        public abstract string Description { get; }
    }
}
