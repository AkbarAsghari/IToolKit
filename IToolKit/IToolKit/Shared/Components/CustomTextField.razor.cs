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
            if (String.IsNullOrEmpty(Class))
            {
                Class = "font-monospace";
            }
            else
            {
                Class += " font-monospace";
            }
        }
    }

    private async Task Copy()
    {
        await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", Text);
    }
}
