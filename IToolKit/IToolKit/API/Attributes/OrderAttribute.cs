namespace IToolKit.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute
    {
        public int? Order { get; set; }

        public OrderAttribute(int order)
        {
            Order = order;
        }
    }
}
