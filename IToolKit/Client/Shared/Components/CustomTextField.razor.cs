using Microsoft.JSInterop;
using MudBlazor;

namespace IToolKit.Client.Shared.Components;
partial class CustomTextField
{
    protected override void OnInitialized()
    {
        base.OnInitialized();
        base.Variant = Variant.Outlined;
    }

    private async Task Copy()
    {
        await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", Text);
    }
}
