using IToolKit.Client.API.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IToolKit.Client.Pages.Settings;

partial class Settings
{
    [Inject] IJSRuntime _JSRuntime { get; set; }
    async Task ClearCacheAndReDownload()
    {
        await _JSRuntime.ClearCache();
        await _JSRuntime.Reload();
    }
}
