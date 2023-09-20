using IToolKit.API.Github;
using IToolKit.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Octokit;

namespace IToolKit.Shared.Components.GitHub;

partial class GitHubStatus
{
    [Inject] IGitHubAPI _GitHubAPI { get; set; }
    [Inject] IJSRuntime _JSRuntime { get; set; }

    Repository repository { get; set; }
    Release lastRelease { get; set; }

    bool showReleaseModal { get; set; }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            repository = await _GitHubAPI.GetRepository();
            lastRelease = await _GitHubAPI.GetLastRelease();
            StateHasChanged();
        }
    }

    async Task Update()
    {
        await _JSRuntime.ClearCache();
        await _JSRuntime.Reload();
    }
}