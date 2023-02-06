using Microsoft.JSInterop;

namespace IToolKit.Shared
{
    public partial class UpdateAvailableDetector
    {
        private bool _newVersionAvailable = false;
        protected override async Task OnInitializedAsync()
        {
            await RegisterForUpdateAvailableNotification();
        }

        private async Task RegisterForUpdateAvailableNotification()
        {
            await _jsRuntime.InvokeAsync<object>(identifier: "registerForUpdateAvailableNotification", DotNetObjectReference.Create(this), nameof(OnUpdateAvailable));
        }

        [JSInvokable(nameof(OnUpdateAvailable))]
        public Task OnUpdateAvailable()
        {
            _newVersionAvailable = true;
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}