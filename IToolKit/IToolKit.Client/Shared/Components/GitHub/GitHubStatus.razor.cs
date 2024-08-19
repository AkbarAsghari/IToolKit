using Blazored.LocalStorage;
using IToolKit.Client.API.Github;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Octokit;

namespace IToolKit.Client.Shared.Components.GitHub;

partial class GitHubStatus
{
    [Inject] IGitHubAPI _GitHubAPI { get; set; }

    Repository repository { get; set; }

    protected override async Task OnInitializedAsync()
    {
        repository = await _GitHubAPI.GetRepository();
    }
}