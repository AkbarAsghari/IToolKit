using IToolKit.API.Attributes;
using IToolKit.API.Extensions;
using IToolKit.API.Interfaces;

namespace IToolKit.API.Assembly
{
    public class AssemblyTools
    {
        public static Dictionary<string, Type> GetRouteAndComponents()
        {
            Dictionary<string, Type> routeAndComponents = new Dictionary<string, Type>();

            GetGroupToolAndTools().ForEach(provider =>
            {
                foreach (var item in provider.Value)
                {
                    routeAndComponents.Add($"Tool/{provider.Key.Route}/{item.Route}".ToLower(), item.Component);
                }
            });

            return routeAndComponents;
        }

        public static IEnumerable<Tuple<string, IToolProvider>> GetRouteAndToolProviders()
        {
            List<Tuple<string, IToolProvider>> routeAndComponents = new List<Tuple<string, IToolProvider>>();

            GetGroupToolAndTools().ForEach(provider =>
            {
                foreach (var item in provider.Value)
                {
                    routeAndComponents.Add(new Tuple<string, IToolProvider>($"Tool/{provider.Key.Route}/{item.Route}".ToLower(), item));
                }
            });

            return routeAndComponents;
        }

        public static Dictionary<IToolProvider, IEnumerable<IToolProvider>> GetGroupToolAndTools()
        {
            Dictionary<IToolProvider, IEnumerable<IToolProvider>> GroupToolAndTools = new Dictionary<IToolProvider, IEnumerable<IToolProvider>>();

            var tools = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype => mytype.GetInterfaces().Contains(typeof(IToolProvider)) &&
                    mytype.IsClass &&
                    !mytype.IsAbstract);

            var groupedToolItems = tools.Where(x => Attribute.GetCustomAttribute(x, typeof(ParentAttribute)) is not null)
                    .GroupBy(x => ((ParentAttribute)Attribute.GetCustomAttribute(x, typeof(ParentAttribute))!).Parent);

            var groupTool = tools.Where(x => Attribute.GetCustomAttribute(x, typeof(ParentAttribute)) is null &&
                Attribute.GetCustomAttribute(x, typeof(NameAttribute)) is not null);

            foreach (var group in groupedToolItems)
            {
                var parent = groupTool.FirstOrDefault(x => ((NameAttribute)Attribute.GetCustomAttribute(x, typeof(NameAttribute))!).Name == group.Key);

                if (parent != null)
                {
                    GroupToolAndTools.Add((IToolProvider)Activator.CreateInstance(parent)!, group.Select(x => (IToolProvider)Activator.CreateInstance(x)!));
                }
            }

            return GroupToolAndTools;
        }
    }
}
