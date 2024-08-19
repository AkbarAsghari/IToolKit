using Microsoft.JSInterop;

namespace IToolKit.Client.API.Extensions
{
    public static class JSRuntimeExtensions
    {
        public static async Task ClearCache(this IJSRuntime jSRuntime)
        {
            await jSRuntime.InvokeVoidAsync("IToolKit.Cache.Clear");
        }

        public static async Task Reload(this IJSRuntime jSRuntime)
        {
            await jSRuntime.InvokeVoidAsync("IToolKit.Location.Reload");
        }
    }
}
