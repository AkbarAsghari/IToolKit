using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace IToolKit.Shared.Components;
partial class CustomTextField
{
    [Parameter] public bool MonoSpace { get; set; }
    protected override void OnInitialized()
    {
        base.OnInitialized();
        base.Variant = Variant.Outlined;
        if (MonoSpace)
        {
            Class += "";
        }
    }

    private async Task Copy()
    {
        await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", Text);
    }
}
