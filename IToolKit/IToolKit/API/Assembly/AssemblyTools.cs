using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;
using IToolKit.Extensions;

namespace IToolKit.API.Assembly
{
    public class AssemblyTools
    {
        public static Dictionary<string, Type> GetRouteAndComponents()
        {
            Dictionary<string, Type> routeAndComponents = new Dictionary<string, Type>();

            GetRouteAndToolProviders().ForEach(provider =>
            {
                routeAndComponents.Add(provider.Key, provider.Value.Component);
            });

            return routeAndComponents;
        }

        public static Dictionary<string, IToolProvider> GetRouteAndToolProviders()
        {
            Dictionary<string, IToolProvider> routeAndComponents = new Dictionary<string, IToolProvider>();

            var tools = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype => mytype.GetInterfaces().Contains(typeof(IToolProvider)) &&
                    mytype.IsClass &&
                    !mytype.IsAbstract);

            var groupedToolItems = tools.Where(x => Attribute.GetCustomAttribute(x, typeof(ParentAttribute)) is not null)
                    .GroupBy(x => ((ParentAttribute)Attribute.GetCustomAttribute(x, typeof(ParentAttribute))!).Parent);

            foreach (var group in groupedToolItems)
            {
                foreach (var tool in group)
                {
                    var _ToolProvider = (IToolProvider)Activator.CreateInstance(tool)!;

                    if (Attribute.GetCustomAttribute(tool, typeof(ParentAttribute)) is not null)
                    {
                        routeAndComponents.Add($"{group.Key}/{_ToolProvider.Route}".ToLower(), _ToolProvider);
                    }
                }
            }

            return routeAndComponents;
        }
    }
}
