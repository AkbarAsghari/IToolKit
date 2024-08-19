using IToolKit.Client.API.Interfaces;

namespace IToolKit.Client.Pages.Tools
{
    internal abstract class GroupToolProviderBase : IToolProvider
    {
        public abstract string Header { get; }

        public abstract string MenuDisplayName { get; }

        public abstract string Description { get; }

        public abstract string Route { get; }

        public abstract Type Component { get; }
    }
}