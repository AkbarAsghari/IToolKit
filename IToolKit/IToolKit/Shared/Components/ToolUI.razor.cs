using IToolKit.API.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IToolKit.Shared.Components;
partial class ToolUI<T>
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment Actions { get; set; }

    IToolProvider _ToolProvider { get; set; }

    protected override Task OnInitializedAsync()
    {
        _ToolProvider = (IToolProvider)Activator.CreateInstance(typeof(T))!;
        return base.OnInitializedAsync();
    }
}
