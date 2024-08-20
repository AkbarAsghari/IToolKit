namespace IToolKit.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class NameAttribute : Attribute
    {
        public string? Name { get; set; }

        public NameAttribute(string? name)
        {
            Name = name;
        }
    }
}
