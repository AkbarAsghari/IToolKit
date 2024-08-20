using IToolKit.API.Assembly;
using IToolKit.API.Extensions;
using IToolKit.API.Interfaces;

namespace IToolKit.Layout
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
