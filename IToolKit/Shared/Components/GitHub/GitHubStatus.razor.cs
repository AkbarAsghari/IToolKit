using Blazored.LocalStorage;
using IToolKit.API.Github;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Octokit;

namespace IToolKit.Shared.Components.GitHub;

partial class GitHubStatus
{
    [Inject] IGitHubAPI _GitHubAPI { get; set; }

    Repository repository { get; set; }

    protected override async Task OnInitializedAsync()
    {
        repository = await _GitHubAPI.GetRepository();
    }
}