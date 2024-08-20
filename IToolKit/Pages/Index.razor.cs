using IToolKit.API.Assembly;
using IToolKit.API.Extensions;
using IToolKit.API.Interfaces;

namespace IToolKit.Pages;

partial class Index
{
    Dictionary<IToolProvider, IEnumerable<IToolProvider>> _GroupAndTools = new Dictionary<IToolProvider, IEnumerable<IToolProvider>>();
    protected override void OnInitialized()
    {
        _GroupAndTools = AssemblyTools.GetGroupToolAndTools().SortByOrderAttribute();
        StateHasChanged();
    }
}
