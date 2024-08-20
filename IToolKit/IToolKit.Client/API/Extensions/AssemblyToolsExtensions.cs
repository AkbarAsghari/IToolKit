using IToolKit.Client.API.Attributes;
using IToolKit.Client.API.Interfaces;
using System.Collections.Generic;

namespace IToolKit.Client.API.Extensions
{
    internal static class AssemblyToolsExtensions
    {
        public static Dictionary<IToolProvider, IEnumerable<IToolProvider>> SortByOrderAttribute(this Dictionary<IToolProvider, IEnumerable<IToolProvider>> source)
        {
            Dictionary<IToolProvider, IEnumerable<IToolProvider>> SortedResult = new Dictionary<IToolProvider, IEnumerable<IToolProvider>>();

            var orderedGroupTools = source.Keys.Where(x => Attribute.GetCustomAttribute(x.GetType(), typeof(OrderAttribute)) is not null)
                .OrderBy(x => ((OrderAttribute)Attribute.GetCustomAttribute(x.GetType(), typeof(OrderAttribute))!).Order);

            foreach (var orderedGroupTool in orderedGroupTools)
            {
                var orderedTools = source[orderedGroupTool].Where(x => Attribute.GetCustomAttribute(x.GetType(), typeof(OrderAttribute)) is not null)
                    .OrderBy(x => ((OrderAttribute)Attribute.GetCustomAttribute(x.GetType(), typeof(OrderAttribute))!).Order);

                SortedResult.Add(orderedGroupTool, orderedTools);
            }

            return SortedResult;
        }

        public static IEnumerable<IToolProvider> SortByOrderAttribute(this IEnumerable<IToolProvider> source)
        {
            return source.Where(x => Attribute.GetCustomAttribute(x.GetType(), typeof(OrderAttribute)) is not null)
                 .OrderBy(x => ((OrderAttribute)Attribute.GetCustomAttribute(x.GetType(), typeof(OrderAttribute))!).Order);
        }
    }
}
