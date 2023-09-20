using IToolKit.API.Github;
using Microsoft.AspNetCore.Components;
using Octokit;

namespace IToolKit.Shared.Components.GitHub;

partial class GitHubStatus
{
    [Inject] IGitHubAPI _GitHubAPI { get; set; }

    Repository repository { get; set; }
    Release lastRelease { get; set; }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            repository = await _GitHubAPI.GetRepository();
            lastRelease = await _GitHubAPI.GetLastRelease();
            StateHasChanged();
        }
    }
}