namespace IToolKit.API.Tools.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ParentAttribute : Attribute
    {
        public string Parent { get; set; }

        public ParentAttribute(string? name)
        {
            Parent = name ?? string.Empty;
        }
    }
}
