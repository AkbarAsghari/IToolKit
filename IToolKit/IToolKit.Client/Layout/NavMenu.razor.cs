using IToolKit.Client.API.Assembly;
using IToolKit.Client.API.Extensions;
using IToolKit.Client.API.Interfaces;

namespace IToolKit.Client.Layout
{
    partial class NavMenu
    {
        Dictionary<IToolProvider, IEnumerable<IToolProvider>> _GroupAndTools = new Dictionary<IToolProvider, IEnumerable<IToolProvider>>();
        protected override void OnInitialized()
        {
            _GroupAndTools = AssemblyTools.GetGroupToolAndTools().SortByOrderAttribute();
            StateHasChanged();
        }
    }
}
