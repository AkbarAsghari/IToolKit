using IToolKit.API.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IToolKit.Shared.Components;
partial class ToolUI<T>
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment Actions { get; set; }

    IToolProvider _ToolProvider { get; set; }
    protected override Task OnParametersSetAsync()
    {
        if (!typeof(IToolProvider).IsAssignableFrom(typeof(T)))
        {
            throw new Exception($"{nameof(T)} must be inherited from {nameof(IToolProvider)}");
        }

        _ToolProvider = (IToolProvider)Activator.CreateInstance(typeof(T))!;
        return base.OnParametersSetAsync();
    }
}
