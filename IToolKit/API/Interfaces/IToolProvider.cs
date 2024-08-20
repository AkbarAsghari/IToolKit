namespace IToolKit.API.Interfaces
{
    public interface IToolProvider
    {
        public string Header { get; }
        public string MenuDisplayName { get; }
        public string Description { get; }
        public string Route { get; }
        public Type Component { get; }
    }
}
